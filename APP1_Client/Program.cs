using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Collections.Generic;

namespace APP1_Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Bienvenue sur notre sondage\n ");

            /*Récupération de descriptifs des sondages*/
            GET().Wait();

            /*Envoie des données*/
            POST().Wait();
        }

        static async Task POST()
        {
            string sondageId, answer, userId;

            string apiUrl = "https://localhost:5001/api/sondage";

            /*Création d'une variable HttpCLient pour les requêtes*/
            using (var client = new HttpClient()) 
            {
				/*******************************
                * **** Début questionnaire ****
                * ****************************/

                /*Mise en place du token dans l'en-tête */
				client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2");

                Console.Write("Veuillez renseigner votre userId (nombre) pour commencer : \n");
				userId = Console.ReadLine();

                bool isNumber = Int32.TryParse(userId, out int number);
                if (isNumber == false)
				{
                    Console.WriteLine("Veuillez mettre un nombre :");
                    return; /*Fin du programme*/
				}

				/*Choix N° sondage */
                Console.Write("Choisir entre le sondage 1 et 2 :\n");
				sondageId = Console.ReadLine();

				if (sondageId == "1")
				{
					/***********************************************************
					 *                     1ere question                       *
					/***********************************************************/

					/*Envoie POST pour récup sondage*/
					var values1 = new Dictionary<string, string>()
                    {
					    {"PollId", sondageId},
					    {"CurrentQuestionId", "-1"},
					    {"test", "first"}
				    };

					var content = new FormUrlEncodedContent(values1);
					var response1 = await client.PostAsync(apiUrl, content);
					var result = await response1.Content.ReadAsStringAsync();
					response1.EnsureSuccessStatusCode();

					/*Affichage question*/
					Console.Write("\n" + result);

					/*Choix réponse 1ere question*/
                    Console.Write("\nVeuillez entrez votre réponse : \n");
					answer = Console.ReadLine();

                    if (!(answer == "a" || answer == "b" || answer == "c" || answer == "d"))
                    {
                        Console.Write("La réponse doit être soit a, b, c ou d.\nMerci.\n");
                        return;
					}

					/*Envoie POST réponse sondage*/
					var values11 = new Dictionary<string, string>()
			        {
				        {"username", userId},
				        {"question", answer},
				        {"PollId", sondageId},
				        {"CurrentQuestionId", "-1"},
					    {"test", "second"}
                    };

					var content11 = new FormUrlEncodedContent(values11);
					var response11 = await client.PostAsync(apiUrl, content11);
					var result11 = await response11.Content.ReadAsStringAsync();
					response11.EnsureSuccessStatusCode();

					/***********************************************************
                     *                     2ème question                       *
                    /***********************************************************/

					/*Affichage question 2*/
					Console.Write("\n" + result11);

					/*Choix réponse */
                    Console.Write("\nVeuillez entrez votre réponse :\n");
					answer = Console.ReadLine();

					if (!(answer == "a" || answer == "b" || answer == "c"))
					{
						Console.Write("La réponse doit être soit a, b ou c.\nMerci.\n");
						return;
					}

					/*Envoie POST réponse sondage*/
					var values2 = new Dictionary<string, string>()
			        {
				        {"username", userId},
				        {"question", answer},
				        {"PollId", sondageId},
				        {"CurrentQuestionId", "12"}
                    };

					var content2 = new FormUrlEncodedContent(values2);
					var response2 = await client.PostAsync(apiUrl, content2);
					var result2 = await response2.Content.ReadAsStringAsync();
					response2.EnsureSuccessStatusCode();

					/***********************************************************
                     *                     3ème question                       *
                    /***********************************************************/

					/*Affichage question 3*/
					Console.Write("\n" + result2);

					/*Choix réponse */
                    Console.Write("\nVeuillez entrez votre réponse :\n");
					answer = Console.ReadLine();

					if (!(answer == "a" || answer == "b" || answer == "c" || answer == "d"))
					{
						Console.Write("La réponse doit être soit a, b, c ou d.\nMerci.\n");
						return;
					}

					/*Envoie POST réponse sondage*/
					var values3 = new Dictionary<string, string>()
			        {
				        {"username", userId},
				        {"question", answer},
				        {"PollId", sondageId},
				        {"CurrentQuestionId", "13"}
                    };

					var content3 = new FormUrlEncodedContent(values3);
					var response3 = await client.PostAsync(apiUrl, content3);
					var result3 = await response3.Content.ReadAsStringAsync();
					response3.EnsureSuccessStatusCode();


					/***********************************************************
                     *                     4ème question                       *
                    /***********************************************************/

					/*Affichage question 3*/
					Console.Write("\n" + result3);

					/*Choix réponse */
                    Console.Write("\nVeuillez entrez votre réponse :\n");
					answer = Console.ReadLine();

					if (!(answer == "a" || answer == "b" || answer == "c" || answer == "d"))
					{
						Console.Write("La réponse doit être soit a, b, c ou d.\nMerci.\n");
						return;
					}

					Console.Write("Merci d'avoir répondu au sondage");

				} 

                else if (sondageId == "2")
                    
				{
					/***********************************************************
                     *                     1ere question                       *
                    /***********************************************************/

					/*Envoie POST pour récup sondage*/
					var values1 = new Dictionary<string, string>()
				    {
					    {"PollId", sondageId},
					    {"CurrentQuestionId", "-1"},
					    {"test", "first"}
				    };

					var content = new FormUrlEncodedContent(values1);
					var response1 = await client.PostAsync(apiUrl, content);
					var result = await response1.Content.ReadAsStringAsync();
					response1.EnsureSuccessStatusCode();


					/*Affichage question*/
					Console.Write("\n" + result);

					/*Choix réponse 1ere question*/
                    Console.Write("\nVeuillez entrez votre réponse :\n");
					answer = Console.ReadLine();

					if (!(answer == "a" || answer == "b" || answer == "c" || answer == "d"))
					{
						Console.Write("La réponse doit être soit a, b, c ou d.\nMerci.\n");
						return;
					}


					/*Envoie POST réponse sondage*/
					var values11 = new Dictionary<string, string>()
			        {
				        {"username", userId},
				        {"question", answer},
				        {"PollId", sondageId},
				        {"CurrentQuestionId", "-1"},
					    {"test", "second"}
			        };

					var content11 = new FormUrlEncodedContent(values11);
					var response11 = await client.PostAsync(apiUrl, content11);
					var result11 = await response11.Content.ReadAsStringAsync();
					response11.EnsureSuccessStatusCode();

					/***********************************************************
                     *                     2ème question                       *
                    /***********************************************************/

					/*Affichage question 2*/
					Console.Write("\n" + result11);

					/*Choix réponse */
                    Console.Write("\nVeuillez entrez votre réponse :\n");
					answer = Console.ReadLine();

					if (!(answer == "a" || answer == "b" || answer == "c"))
					{
						Console.Write("La réponse doit être soit a, b ou c.\nMerci.\n");
						return;
					}

					/*Envoie POST réponse sondage*/
					var values2 = new Dictionary<string, string>()
			        {
				        {"username", userId},
				        {"question", answer},
				        {"PollId", sondageId},
				        {"CurrentQuestionId", "22"}
			        };

					var content2 = new FormUrlEncodedContent(values2);
					var response2 = await client.PostAsync(apiUrl, content2);
					var result2 = await response2.Content.ReadAsStringAsync();
					response2.EnsureSuccessStatusCode();

					/***********************************************************
                     *                     3ème question                       *
                    /***********************************************************/

					/*Affichage question 3*/
					Console.Write("\n" + result2);

					/*Choix réponse */
                    Console.Write("\nVeuillez entrez votre réponse :\n");
					answer = Console.ReadLine();

					if (!(answer == "a" || answer == "b" || answer == "c" || answer == "d"))
					{
						Console.Write("La réponse doit être soit a, b, c ou d.\nMerci.\n");
						return;
					}

					/*Envoie POST réponse sondage*/
					var values3 = new Dictionary<string, string>()
			        {
				        {"username", userId},
				        {"question", answer},
				        {"PollId", sondageId},
				        {"CurrentQuestionId", "23"}
			        };

					var content3 = new FormUrlEncodedContent(values3);
					var response3 = await client.PostAsync(apiUrl, content3);
					var result3 = await response3.Content.ReadAsStringAsync();
					response3.EnsureSuccessStatusCode();


					/***********************************************************
                     *                     4ème question                       *
                    /***********************************************************/

					/*Affichage question 3*/
					Console.Write("\n" + result3);

					/*Choix réponse */
                    Console.Write("\nVeuillez entrez votre réponse :\n");
					answer = Console.ReadLine();

					if (!(answer == "a" || answer == "b" || answer == "c" || answer == "d"))
					{
						Console.Write("La réponse doit être soit a, b, c ou d.\nMerci.\n");
						return;
					}

					Console.Write("Merci d'avoir répondu au sondage");
                } 

                else 
                
                {
                    Console.Write("Sondage indisponible.\n");
					Console.Write("Veuillez choisir entre 1 et 2.\n");
                    return;
				}
			}
        }

        /*******************************************************
         * Méthode pour récupérer les descriptifs des sondages *
         * ****************************************************/
        static async Task GET()
		{
			using (var clientHandlerGET = new HttpClientHandler())
			{
				using (var clientGET = new HttpClient())
				{
					clientGET.DefaultRequestHeaders.Accept.Clear();
					clientGET.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

					/*Mise en place du token dans l'en-tête */
					clientGET.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2");

                    var stringContent = clientGET.GetStringAsync("https://localhost:5001/api/sondage");
					var message = await stringContent;
                    Console.Write("\nVoici les sondages disponibles :\n" + message + "\n");
                    Console.Write(("\n"));
				}

			}
		}
	}
}
