﻿using System;
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
            /*
            Task T = new Task(Request_GET);
			T.Start();
			Console.WriteLine("Json data........");
			Console.ReadLine();
			*/

            Console.Write("POST :");
            POST().Wait();

            Console.Write("\nGET :");
            GET().Wait();
		}

		/*		static async void Request_GET()
				{
					var r = await GETPage("https://localhost:5001/api/values");
					Console.WriteLine(r.Substring(0, 50));
				}

		private HttpClientHandler AddCert(HttpClientHandler clientHandler, string certFilename)
			{
				var certPfx = new X509Certificate2(certFilename);
				clientHandler.SslProtocols = SslProtocols.Tls12;
				clientHandler.ClientCertificateOptions = ClientCertificateOption.Manual;
				clientHandler.ClientCertificates.Add(certPfx);

				clientHandler.ServerCertificateCustomValidationCallback += 
					(HttpRequestMessage req, X509Certificate2 cert2, X509Chain chain, SslPolicyErrors err) => { return true; };

				return clientHandler;
			}
		*/


        static async Task POST()
        {
            using (var clientHandler = new HttpClientHandler())
            {
	/*			var certPfx = new X509Certificate2("certificat.pfx");
				clientHandler.SslProtocols = SslProtocols.Tls12;
				clientHandler.ClientCertificateOptions = ClientCertificateOption.Manual;
				clientHandler.ClientCertificates.Add(certPfx);

				clientHandler.ServerCertificateCustomValidationCallback +=
			(HttpRequestMessage req, X509Certificate2 cert2, X509Chain chain, SslPolicyErrors err) => { return true; };
*/
                /*C'est une faille de sécurité mais nous avons un certificat auto-signé alors qu'il en faudrait 1 signé*/
                clientHandler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;

                using (var clientPOST = new HttpClient())
                {
					//HttpClient client1 = new HttpClient(clientHandler);
                    clientPOST.BaseAddress = new Uri("https://localhost:5001/api/");
					clientPOST.DefaultRequestHeaders.Accept.Clear();
					clientPOST.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

					// HTTP POST
                    var dataToBeSent = new ApiSendData()
					{
						PollId = 1,
                        CurrentQuestionId = -1
					};

                    
                    HttpResponseMessage response = await clientPOST.PostAsJsonAsync("sondage", dataToBeSent);


					if (response.IsSuccessStatusCode)
					{
						// Get the URI of the created resource.
						Uri ncrUrl = response.Headers.Location;

                        // do whatever you need to do here with the returned data //
                        Console.Write(response);

					}
                }
            }
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
