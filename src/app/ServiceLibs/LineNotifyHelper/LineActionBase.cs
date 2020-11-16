
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

    public class LineActionBase : ILineAction
    {
        protected readonly IHttpClientFactory factory = null;

        protected ManualResetEvent waitObject = null;
        
        public LineActionBase(IHttpClientFactory factoryHttpClient, ManualResetEvent waitObject)
        {
            this.factory = factoryHttpClient;
            this.waitObject = waitObject;
        }

        public virtual Task Execute(NameValueCollection dataRepo)
        {
            return Task.FromResult(string.Empty);
        }
    }
}
