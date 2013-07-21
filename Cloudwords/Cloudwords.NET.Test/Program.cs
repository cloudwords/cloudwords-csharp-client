using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cloudwords.NET;
using Cloudwords.NET.Classes;
namespace Cloudwords.NET.Test
{
    class Program
    {
        static CloudwordsClient client;
        static void Main(string[] args)
        {
           client = new CloudwordsClient(true, "bb8568eb355aa091fb5bee0fcad5e902afd5f268217919488c269fbd3de73455");

            // Test Create Project function
            //Console.WriteLine(CreateProject_Test());

            // Test Get Project function
            Console.WriteLine(GetProject_Test());

            Console.ReadLine();

        }
        private static string CreateProject_Test()
        {
             List<string> targetLanguage = new List<string>();
            targetLanguage.Add("fr");

            List<int> follower = new List<int>();
            follower.Add(845);
            return client.CreateProject("test project 7", "This is a test project 7", "en-us", targetLanguage,
                                    DateTime.Now.AddDays(3).ToString("yyyy-MM-ddTHH:mm:ss.fffZ", System.Globalization.CultureInfo.InvariantCulture),
                                    DateTime.Now.AddDays(6).ToString("yyyy-MM-ddTHH:mm:ss.fffZ", System.Globalization.CultureInfo.InvariantCulture),
                                    DateTime.Now.AddDays(7).ToString("yyyy-MM-ddTHH:mm:ss.fffZ", System.Globalization.CultureInfo.InvariantCulture), 
                                    "testing notes", 1143, 0,null, null,null);

        }
        private static string GetProject_Test()
        {
            return client.GetProject(10149);
        }

        
    }
}
