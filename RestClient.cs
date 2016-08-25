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
        public RestClient (string baseUrl, string username, string password)
        {
            this.baseUrl = baseUrl + "/";
            this.httpClient = new HttpClient();
            var byteArray = Encoding.ASCII.GetBytes($"{username}:{password}");
            this.httpClient.DefaultRequestHeaders.Authorization = 
            new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
        }

        public async Task PostAsync(string payload, string path){
            Console.WriteLine($"Preparing payload of: {payload} to {this.baseUrl + path}.");
            HttpContent contentPost = new System.Net.Http.StringContent(payload, Encoding.UTF8, "application/json");
            var response = await this.httpClient.PostAsync(this.baseUrl + path, contentPost);
            var responseString = await response.EnsureSuccessStatusCode().Content.ReadAsStringAsync();
            Console.WriteLine($"Received: {responseString}.");            
        }

        public async Task<string> GetAsync(string path){
            var response = await this.httpClient.GetAsync(this.baseUrl + path);
            var responseString = await response.EnsureSuccessStatusCode().Content.ReadAsStringAsync();
            return responseString;           
        }

        public void Dispose()
        {
            httpClient.Dispose();
        }
    }
}