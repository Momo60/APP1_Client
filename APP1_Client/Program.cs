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
         
            Console.Write("Bienvenue sur notre site veuillez choisir le sondage auquel vous souhaitez répondre");

            Console.Write("\nGET :\n");
            GET().Wait();


			Console.Write("POST :\n");
			POST().Wait();
		}



		
        static async Task POST()
        {
            string question;
            string numero;
            string rep;
            string apiUrl = "https://localhost:5001/api/sondage";
            var client = new HttpClient();

            Console.Write("Veuillez choisir le questionnaire auquel vous souhaitez répondre\n");
            question = Console.ReadLine();
            Console.Write("Veuillez choisir la question à laquelle vous souhaitez répondre\n");
            numero = Console.ReadLine();
            var values = new Dictionary<string, string>()
            {   
                {"PollId", question},
                {"CurrentQuestionId", numero},
                
            };
            var content = new FormUrlEncodedContent(values);

            var response = await client.PostAsync(apiUrl, content);
            var result = await response.Content.ReadAsStringAsync();
            response.EnsureSuccessStatusCode();
            Console.Write("\n"+result);
			
            Console.Write("Veuillez entrez votre réponse \n");
            rep = Console.ReadLine();

		}
		
  

		static async Task GET()
		{
			using (var clientHandlerGET = new HttpClientHandler())
			{
				using (var clientGET = new HttpClient())
				{
					clientGET.DefaultRequestHeaders.Accept.Clear();
					clientGET.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    clientGET.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2");

                    var stringContent = clientGET.GetStringAsync("https://localhost:5001/api/sondage");
					var message = await stringContent;
					Console.Write("\nPrint :\n" + message + "\n");

				
				}


			}
		}
	}
}
