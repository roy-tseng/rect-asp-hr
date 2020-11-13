
namespace TestDBHelper
{
    using System.IO;
    using NUnit.Framework;
    using INFOLINK.DBHelper;

    public class Tests
    {
        private SeedHandler seedHandler {get; set;} = null;

        private string source = string.Empty;

        [SetUp]
        public void Setup()
        {
            string connectionString = "server=localhost;port=3308;database=hr;user id=root;password=root";
            this.source = "hr.xlsx";
            this.seedHandler = new ExcelSeedHandler(connectionString, source);
        }

        [Test]
        public void Test_Pass_DumpDataToDB()
        {
            int effectedRow = 0;
            Assert.IsTrue(File.Exists(this.source));
            Assert.IsTrue(this.seedHandler.DumpDataToDB("Employee", true, out effectedRow));
            Assert.IsTrue(this.seedHandler.CloseConnection());
        }

        [Test]
        public void Test_Pass_DBConnection()
        {
            Assert.IsTrue(this.seedHandler.OpenDBConnection());
            Assert.IsTrue(this.seedHandler.CloseConnection());
        }
    }
}