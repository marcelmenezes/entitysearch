using System;
using System.Linq;
using System.Text;

using Microsoft.Azure.CognitiveServices.Search.WebSearch;
using Microsoft.Azure.CognitiveServices.Search.WebSearch.Models;
using Microsoft.Azure.CognitiveServices.Search.EntitySearch;
using Microsoft.Azure.CognitiveServices.Search.EntitySearch.Models;
using Newtonsoft.Json;

namespace ConsoleEntitySearch
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {

                var client = new EntitySearchClient(new Microsoft.Azure.CognitiveServices.Search.EntitySearch.ApiKeyServiceClientCredentials("499a3aed7bd94abbbd063b5386d0057c"));
                var entityData = client.Entities.Search(query: "Microsoft");
                var mainEntity = entityData.Entities.Value.Where(thing => thing.EntityPresentationInfo.EntityScenario == EntityScenario.DominantEntity).FirstOrDefault();



                WebSearchClient clientS = new WebSearchClient(new Microsoft.Azure.CognitiveServices.Search.WebSearch.ApiKeyServiceClientCredentials("e8a0a5c87ce7475480363a5df584c1aa"));
                clientS.Endpoint = "https://eastus2.api.cognitive.microsoft.com/";

                WebResults(clientS);


                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
                //var consulta = clientS.Web.SearchAsync(query: "Microsoft");

            }
        }

        public static async void WebResults(WebSearchClient client)
        {
            try
            {
                //var webData = await client.Web.SearchAsync(query: "Yosemite National Park");
                var webData = await client.Web.SearchAsync(query: "BRADESCO");
                Console.WriteLine("Searching for \"Yosemite National Park\"");

                // Code for handling responses is provided in the next section...

            }
            catch (Exception ex)
            {
                Console.WriteLine("Encountered exception. " + ex.Message);
            }
        }
    }
}
