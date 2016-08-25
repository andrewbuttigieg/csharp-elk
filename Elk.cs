using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ConsoleApplication
{
    public class Elk{

        public string Endpoint { get; private set; }
        private string Username { get;}
        private string Password { get;}
        public Elk (string endpoint, string username, string password)
        {
            this.Endpoint = endpoint;
            this.Username = username; 
            this.Password = password;
        }

        public async Task Send(object payload, string index, string type){
            await this.Send(JsonConvert.SerializeObject(payload), index, type);
        }

        public async Task Send(string payload, string index, string type){
            using (var restClient = new RestClient(this.Endpoint, this.Username, this.Password))
            {
                await restClient.PostAsync(payload, $"{index}/{type}");
            }
        }
    }
}