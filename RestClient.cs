using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ConsoleApplication
{
    public class RestClient: IDisposable
    {
        private string baseUrl { get; set; }
        private HttpClient httpClient { get; }
        public RestClient (string baseUrl)
        {
            this.baseUrl = baseUrl + "/";
            this.httpClient = new HttpClient();
        }

        public async Task PostAsync(object data, string path){
            var payload = JsonConvert.SerializeObject(data);
            Console.WriteLine($"Preparing payload of: {payload}.");
            HttpContent contentPost = new System.Net.Http.StringContent(payload, Encoding.UTF8, "application/json");
            var response = await this.httpClient.PostAsync(this.baseUrl + path, contentPost);
            //await response.EnsureSuccessStatusCode().Content.ReadAsAsync();
        }

        public void Dispose()
        {
            httpClient.Dispose();
        }
    }
}