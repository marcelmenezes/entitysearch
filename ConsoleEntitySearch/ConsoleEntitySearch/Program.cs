using System;
using System.Linq;
using System.Text;

using Microsoft.Azure.CognitiveServices.Search.WebSearch;
using Microsoft.Azure.CognitiveServices.Search.WebSearch.Models;
using Microsoft.Azure.CognitiveServices.Search.EntitySearch;
using Microsoft.Azure.CognitiveServices.Search.EntitySearch.Models;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace ConsoleEntitySearch
{
    class Program
    {
        static void Main(string[] args)
        {

            //MainAsync();
            //Task.Run(async () =>
            //{
            //    await MainAsync();
            //});


            Task.WaitAll(MainAsync());

            Task.Run(async () =>
            {
                await MainAsync();
            }).GetAwaiter().GetResult();

            Console.WriteLine("texto 1");
            Console.ReadLine();
        }

        static async Task MainAsync()
        {
            while (true)
            {
                var QUERY = "banco do brasil seguros";
                var client = new EntitySearchClient(new Microsoft.Azure.CognitiveServices.Search.EntitySearch.ApiKeyServiceClientCredentials("499a3aed7bd94abbbd063b5386d0057c"));
                var entityData = client.Entities.Search(QUERY);

                if (entityData.Entities != null)
                {
                    var mainEntity = entityData.Entities.Value.Where(thing => thing.EntityPresentationInfo.EntityScenario == EntityScenario.DominantEntity).FirstOrDefault();
                }


                WebSearchClient clientS = new WebSearchClient(new Microsoft.Azure.CognitiveServices.Search.WebSearch.ApiKeyServiceClientCredentials("e8a0a5c87ce7475480363a5df584c1aa"));
                clientS.Endpoint = "https://eastus2.api.cognitive.microsoft.com/";

                var tasl = await WebResults(clientS, QUERY);

                ExibeJson(tasl);

                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
                //var consulta = clientS.Web.SearchAsync(query: "Microsoft");

            }
        }

        public static void ExibeJson(Microsoft.Azure.CognitiveServices.Search.WebSearch.Models.SearchResponse webData)
        {
            if (webData?.WebPages?.Value?.Count > 0)
            {
                // find the first web page
                var firstWebPagesResult = webData.WebPages.Value.FirstOrDefault();

                if (firstWebPagesResult != null)
                {
                    Console.WriteLine("Webpage Results # {0}", webData.WebPages.Value.Count);
                    Console.WriteLine("First web page name: {0} ", firstWebPagesResult.Name);
                    Console.WriteLine("First web page URL: {0} ", firstWebPagesResult.Url);
                }
                else
                {
                    Console.WriteLine("Didn't find any web pages...");
                }
            }
            else
            {
                Console.WriteLine("Didn't find any web pages...");
            }

            /*
             * Images
             * If the search response contains images, the first result's name
             * and url are printed.
             */
            if (webData?.Images?.Value?.Count > 0)
            {
                // find the first image result
                var firstImageResult = webData.Images.Value.FirstOrDefault();

                if (firstImageResult != null)
                {
                    Console.WriteLine("Image Results # {0}", webData.Images.Value.Count);
                    Console.WriteLine("First Image result name: {0} ", firstImageResult.Name);
                    Console.WriteLine("First Image result URL: {0} ", firstImageResult.ContentUrl);
                }
                else
                {
                    Console.WriteLine("Didn't find any images...");
                }
            }
            else
            {
                Console.WriteLine("Didn't find any images...");
            }

            /*
             * News
             * If the search response contains news articles, the first result's name
             * and url are printed.
             */
            if (webData?.News?.Value?.Count > 0)
            {
                // find the first news result
                var firstNewsResult = webData.News.Value.FirstOrDefault();

                if (firstNewsResult != null)
                {
                    Console.WriteLine("\r\nNews Results # {0}", webData.News.Value.Count);
                    Console.WriteLine("First news result name: {0} ", firstNewsResult.Name);
                    Console.WriteLine("First news result URL: {0} ", firstNewsResult.Url);
                }
                else
                {
                    Console.WriteLine("Didn't find any news articles...");
                }
            }
            else
            {
                Console.WriteLine("Didn't find any news articles...");
            }

            /*
             * Videos
             * If the search response contains videos, the first result's name
             * and url are printed.
             */
            if (webData?.Videos?.Value?.Count > 0)
            {
                // find the first video result
                var firstVideoResult = webData.Videos.Value.FirstOrDefault();

                if (firstVideoResult != null)
                {
                    Console.WriteLine("\r\nVideo Results # {0}", webData.Videos.Value.Count);
                    Console.WriteLine("First Video result name: {0} ", firstVideoResult.Name);
                    Console.WriteLine("First Video result URL: {0} ", firstVideoResult.ContentUrl);
                }
                else
                {
                    Console.WriteLine("Didn't find any videos...");
                }
            }
            else
            {
                Console.WriteLine("Didn't find any videos...");
            }
        }

        public static async Task<Microsoft.Azure.CognitiveServices.Search.WebSearch.Models.SearchResponse> WebResults(WebSearchClient client, string query)
        {
            //var webData = await client.Web.SearchAsync(query: "Yosemite National Park");
            var webData = await client.Web.SearchAsync(query: query);
            Console.WriteLine(string.Format("Searching for '{0}':", webData.QueryContext.OriginalQuery));


            return webData;

            // Code for handling responses is provided in the next section...

        }
    }
}
