using HRIS_Payroll_Offsets.Settings;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace HRIS_Payroll_Offsets.Communication
{
    internal class Reports<T>
    {
        private const int MaxWait = 30;

        public async Task<T> GetRptDataAsync(string url)
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

            try
            {
                var hnd = new HttpClientHandler
                {
                    Credentials = new NetworkCredential(AppSettings.UserId, AppSettings.UserPw),
                };

                using (var client = new HttpClient(hnd))
                {
                    client.Timeout = TimeSpan.FromMinutes(MaxWait);

                    var response = await client.GetAsync(url);
                    if (!response.IsSuccessStatusCode) throw new Exception("Response indicates failure:" + response.RequestMessage.ToString());

                    return JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
                }
            }
            catch (AggregateException agg)
            {
                Debug.WriteLine(agg.ToString());
                Debugger.Break();
                throw;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                Debugger.Break();
                throw;
            }
        }
    }
}
