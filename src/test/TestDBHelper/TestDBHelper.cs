
namespace TestDBHelper
{
    using NUnit.Framework;
    using INFOLINK.DBHelper;

    public class Tests
    {
        private ISeedHandler seedHandler {get; set;} = null;

        [SetUp]
        public void Setup()
        {
            this.seedHandler = new ExcelSeedHandler();
        }

        [Test]
        public void Test1()
        {
            Assert.IsTrue(this.seedHandler.DumpDataToDB(string.Empty));
            Assert.Pass();
        }
    }
}