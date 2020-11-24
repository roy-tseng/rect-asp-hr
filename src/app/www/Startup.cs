namespace rect_asp_hr
{
    using System.Text;
    using System.Text.Encodings;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.HttpsPolicy;
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.IdentityModel.Tokens;
    using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
    using infolink.rect_asp_hr.Models;
    using INFOLINK.ShareLibs;

    public class Startup
    {
        private readonly string corsPolicy = "CorsPolicy";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllersWithViews();

            // In production, the React files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/build";
            });

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(this.SetupJWTBearer);
            services.AddAuthorization();
            services.AddSingleton<JWTHelper>();

            string connectionString = Configuration.GetConnectionString("mysql");
            services.AddDbContext<MySQLContext>(options => options.UseMySql(connectionString));
            this.EnableCORS(services);         
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();
            app.UseCors(this.corsPolicy);
            app.UseRouting();
        
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                spa.ApplicationBuilder.UseCors(this.corsPolicy);

                if (env.IsDevelopment())
                {
                    spa.UseReactDevelopmentServer(npmScript: "start");
                }
            });
        }

        private void EnableCORS(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(this.corsPolicy, policy =>
                {
                    policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod().Build();
                });
            });
        }

        private void SetupJWTBearer(JwtBearerOptions options)
        {
            // 當驗證失敗時，回應標頭會包含 WWW-Authenticate 標頭，這裡會顯示失敗的詳細錯誤原因
            options.IncludeErrorDetails = true; // 預設值為 true，有時會特別關閉

            options.TokenValidationParameters = new TokenValidationParameters()
            {
                // 透過這項宣告，就可以從 "sub" 取值並設定給 User.Identity.Name
                NameClaimType = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier",
                // 透過這項宣告，就可以從 "roles" 取值，並可讓 [Authorize] 判斷角色
                RoleClaimType = "http://schemas.microsoft.com/ws/2008/06/identity/claims/role",

                // 一般我們都會驗證 Issuer
                ValidateIssuer = true,
                ValidIssuer = Configuration.GetValue<string>("JwtSettings:Issuer"),

                // 通常不太需要驗證 Audience
                ValidateAudience = false,
                //ValidAudience = "JwtAuthDemo", // 不驗證就不需要填寫

                // 一般我們都會驗證 Token 的有效期間
                ValidateLifetime = true,

                // 如果 Token 中包含 key 才需要驗證，一般都只有簽章而已
                ValidateIssuerSigningKey = false,

                // "1234567890123456" 應該從 IConfiguration 取得
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration.GetValue<string>("JwtSettings:SignKey")))
            };
        }
    }
}        
