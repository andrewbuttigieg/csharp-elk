using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ConsoleApplication
{
    public class Elk{

        public string Endpoint { get; private set; }
        public Elk (string endpoint)
        {
            this.Endpoint = endpoint; 
        }

        public async Task Send(object payload, string index, string type){
            await this.Send(JsonConvert.SerializeObject(payload), index, type);
        }

        public async Task Send(string payload, string index, string type){
            using (var restClient = new RestClient(this.Endpoint))
            {
                await restClient.PostAsync(payload, $"{index}/{type}");
            }
        }
    }
}