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
         
            Console.Write("Bienvenue sur notre site ");

            Console.Write("\nGET :\n");
            GET().Wait();


			Console.Write("POST :\n");
			POST().Wait();
		}



		
        static async Task POST()
        {
            string sondageId;
            string answer;
            string userId;
            string apiUrl = "https://localhost:5001/api/sondage";
            var client = new HttpClient();

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2");
            Console.Write("veuillez renseigner votre Username\n");
            userId= Console.ReadLine();

			Console.Write("Choisir entre le questionnaire 1 et 2\n");
			sondageId = Console.ReadLine();

            var values = new Dictionary<string, string>()
            {   
                {"PollId", sondageId},
                {"CurrentQuestionId", "-1"},
                {"answer", answer},
                {"username", userId},

                
            };
            var content = new FormUrlEncodedContent(values);

            var response = await client.PostAsync(apiUrl, content);
            var result = await response.Content.ReadAsStringAsync();
            response.EnsureSuccessStatusCode();
            Console.Write("\n"+result);
			
            Console.Write("\nVeuillez entrez votre réponse \n");
            answer = Console.ReadLine();



            /*
            var values2 = new Dictionary<string, string>()
			{
				{"userId", userId},
				{"question", repo},

			};
            var content2 = new FormUrlEncodedContent(values2);
            var sendAnswer = await client.PostAsync(apiUrl, content2);
			var result2 = await response.Content.ReadAsStringAsync();
			response.EnsureSuccessStatusCode();
*/
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
