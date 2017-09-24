using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Collections.Generic;
using System.Runtime.Serialization.Json;
using System.Security.Cryptography.X509Certificates;
using System.Security.Authentication;
using System.Net.Security;
using System.IO;
using System.Text;

namespace APP1_Client
{
    class Program
    {
        class ApiSendData
        {
            public int PollId { get; set; }
            public int CurrentQuestionId { get; set; }
        }
			
            static void Main(string[] args)
        {
         

            Console.Write("\nGET :");
            GET().Wait();

			Console.Write("POST :");
			POST().Wait();
		}



		
        static async Task POST()
        {
         string apiUrl = "https://localhost:5001/api/sondage";
            var client = new HttpClient();
            var values = new Dictionary<string, string>()
            {   
                {"PollId", "1"},
                {"CurrentQuestionId", "-1"},
                
            };
            var content = new FormUrlEncodedContent(values);

            var response = await client.PostAsync(apiUrl, content);
            var result = await response.Content.ReadAsStringAsync();
            response.EnsureSuccessStatusCode();
            Console.Write("\n"+result);

		}
		
  

		static async Task GET()
		{
			using (var clientHandlerGET = new HttpClientHandler())
			{
				using (var clientGET = new HttpClient())
				{
					clientGET.DefaultRequestHeaders.Accept.Clear();
					clientGET.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var stringContent = clientGET.GetStringAsync("https://localhost:5001/api/sondage");
					var message = await stringContent;
					Console.Write("\nPrint :\n" + message + "\n");

				
				}


			}
		}
	}
}
