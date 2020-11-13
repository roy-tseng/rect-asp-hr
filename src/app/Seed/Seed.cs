namespace INFOLINK.DBHelper
{
    using System;
    using Microsoft.Extensions.Configuration;
    using INFOLINK.ShareLibs;

    public class Seed
    {
        static void Main(string[] args)
        {
            string connectionString = string.Empty;
            IConfiguration config = new ConfigurationBuilder()
          .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
          .Build();
            connectionString = config.GetConnectionString("mysql");
            string seedSource = args.Length == 1 ? args[0] : string.Empty;
            
            int effectedRow = 0;
            Logger.Log(Logger.Level.Info, string.Format("source = {0}, connection string= {1} ", seedSource, connectionString));
            
            SeedHandler handler = new ExcelSeedHandler(connectionString, seedSource);
            handler.DumpDataToDB(string.Empty, true, out effectedRow);
        }
    }
}
