using NUnit.Framework;

namespace TestLineNotifyHelper
{
    using INFOLINK.LineAPP.Notify;
    using System.Collections.Specialized;

    public class Tests
    {
        private LineNotifyService lineService = null;
        private NameValueCollection dict = new NameValueCollection();
       

        [SetUp]
        public void Setup()
        {
            this.lineService = new LineNotifyService();
            this.dict.Clear();
            this.dict.Add(LineOfficialAddress.LINENOTIFY_MSG,string.Empty);
            this.dict.Add(LineOfficialAddress.LINENOTIFY_TOKEN,"2NPnKfgwIaTcMAojs9P1ji0MWckkh15JLnobeGWQOg8");
        }

        [Test]
        public  void Test_LineNotify_Notify_Pass()
        { 
             this.lineService.Execute(this.dict);
            Assert.Pass();
        }
    }
}