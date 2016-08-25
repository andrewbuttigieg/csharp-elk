using System;
using System.Threading.Tasks;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try{
                var elk = new Elk("https://99a6e754369e9a203f09b7d35bca103e.us-east-1.aws.found.io:9243", "test", "Password");
                Task post = elk.Send(@"{
""title"": ""One"", ""tags"": [""ruby""]
}", "my_index", "my_type");
                post.Wait();
                Console.WriteLine("Posted data successfully.");

                    // Task<string> getTask = restClient.GetAsync("my_index/my_type/AVa-YBVvwAe1bwBblOZG");
                    // getTask.Wait();
                    // var response = getTask.Result;
                    // Console.WriteLine($"Got data:\n{response}");

                    // Task<string> getAllTask = restClient.GetAsync("my_index/_search");
                    // getAllTask.Wait();
                    // var responseAll = getAllTask.Result;
                    // Console.WriteLine($"Got data:\n{responseAll}");
            }
            catch(Exception e){
                Console.WriteLine(e);
            }
        }
    }
}
