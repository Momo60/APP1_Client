using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Collections.Generic;
using System.Runtime.Serialization.Json;

namespace APP1_Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bienvenue sur notre site, Veuillez choisir le sondage!");
            ProcessRepositories().Wait();
            Console.ReadKey();
		}

		
			private static async Task ProcessRepositories()
			{
				var client = new HttpClient();
				client.DefaultRequestHeaders.Accept.Clear();
				client.DefaultRequestHeaders.Accept.Add(
					new MediaTypeWithQualityHeaderValue("application/json"));
				client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");
                var stringTask = client.GetStringAsync("https://localhost:5001/api/values");
			    var msg = await stringTask;
			    Console.Write(msg);

		   }
    }
}
