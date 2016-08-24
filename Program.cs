using System;
using System.Threading.Tasks;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try{
                using (var restClient = new RestClient("https://99a6e754369e9a203f09b7d35bca103e.us-east-1.aws.found.io:9243")){
                    Task task = restClient.PostAsync((object)@"{
    ""title"": ""One"", ""tags"": [""ruby""]
    }", "my_index/my_type");
                    task.Wait();
                    Console.WriteLine("Posted data successfully.");
                }
            }
            catch(Exception e){
                Console.WriteLine(e);
            }
        }
    }
}
