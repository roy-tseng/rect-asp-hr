namespace INFOLINK.LineAPP.Notify
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using INFOLINK.ShareLibs;

    public class LineNotifyService : ILineAction
    {
        private LineActionBase action = null;

        private ManualResetEvent waitObject = new ManualResetEvent(false);

        public LineNotifyService()
        {
            this.action = new LineNotifySendText(null, WaitObject);
        }

        public ManualResetEvent WaitObject
        {
            get { return this.waitObject;  }
            set { this.waitObject = value; }
        }

        public async Task Execute(NameValueCollection dataRepo)
        {
            try
            {
                this.waitObject.Reset();
                await this.action.Execute(dataRepo);
            }
            catch (Exception ex)
            {
                Logger.Log(Logger.Level.Error, ex.Message);
            }

            return;
        }
    }
}
