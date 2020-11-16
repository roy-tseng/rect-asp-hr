
namespace INFOLINK.LineAPP.Notify
{
    using System;
    using System.Collections.Specialized;
    using System.Diagnostics;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading;
    using System.Threading.Tasks;
    using INFOLINK.ShareLibs;

    public class LineNotifySendText : LineActionBase
    {
        public LineNotifySendText(IHttpClientFactory factoryHttpClient, ManualResetEvent waitObject) :base(factoryHttpClient, waitObject)
        {
        }

        public override async Task Execute(NameValueCollection dataRepo)
        {
            try
            {
                HttpClient client = this.factory == null ? new HttpClient() : this.factory.CreateClient();
                client.Timeout = new TimeSpan(0, 0, 60);
                client.BaseAddress = new Uri(LineOfficialAddress.LINENOTITY_NOTITY_ADDRESS);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", dataRepo[LineOfficialAddress.LINENOTIFY_TOKEN]);

                StringContent content = new StringContent($"message={dataRepo[LineOfficialAddress.LINENOTIFY_MSG]}",
                                                          System.Text.Encoding.UTF8,
                                                          "application/x-www-form-urlencoded");
                var response = await client.PostAsync("", content);

                if (!response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"error: {responseContent}, token: {dataRepo[LineOfficialAddress.LINENOTIFY_TOKEN]}");
                    if (this.waitObject != null)
                    {
                        this.waitObject.Set();
                    }
                }
                else
                {
                    if (this.waitObject != null)
                    {
                        this.waitObject.Set();
                    }
                }
            }
            catch(Exception ex)
            {
                Logger.Log(Logger.Level.Error, ex.Message);
            }

            return;
        }
    }
}
