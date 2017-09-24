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
            Task T = new Task(Request_GET);
			T.Start();
			Console.WriteLine("Json data........");
			Console.ReadLine();
		}

		static async void Request_GET()
		{
			var r = await GETPage("https://localhost:5001/api/values");
			Console.WriteLine(r.Substring(0, 50));
		}

		static async Task<string> GETPage(string url)
		{
			using (var client = new HttpClient())
			{
				using (var httpClientHandler = new HttpClientHandler())
				{

					/*C'est une faille de sécurité mais nous avons un certificat auto-signé alors qu'il en faudrait 1 signé*/
					httpClientHandler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;

                    client.BaseAddress = new Uri(url);
					//HTTP GET
					var responseTask = client.GetAsync("/5");
					Console.Write(responseTask);
					responseTask.Wait();

                    string result = responseTask.Result.ToString();
                    return result;
				}

			}

		}
	}
}
