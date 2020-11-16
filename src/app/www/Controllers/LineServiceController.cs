namespace rect_asp_hr.Controllers
{
    using INFOLINK.LineAPP.Notify;
    using INFOLINK.ShareLibs;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;

    //[AllowCrossSiteJson]
    public class LineServiceController : Controller
    {
        public LineServiceController()
        {
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> SendTextNotify([FromForm]string? message)
        {
            return new JsonResult(await this.SendText(message));
        }

        private async Task<string> SendText(string message)
        {
            string responseContent = string.Empty;

            try
            {
                HttpClient client = new HttpClient();
                string token = string.Empty;
                client.Timeout = new TimeSpan(0, 0, 60);
                client.BaseAddress = new Uri(LineOfficialAddress.LINENOTITY_NOTITY_ADDRESS);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                StringContent content = new StringContent($"message={message}",
                                                          System.Text.Encoding.UTF8,
                                                          "application/x-www-form-urlencoded");
                var response = await client.PostAsync("", content);
                responseContent = await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                Logger.Log(Logger.Level.Error, ex.Message);
            }

            return responseContent;
        }
    }
}