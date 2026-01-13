using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace TutorialProject.Gemini
{
    public class Manager
    {
        public async Task Start()
        {
            Console.Write("Ask Gemini: ");
            var prompt = Console.ReadLine();

            FetchGeminiContent(prompt).Wait();
        }
        public async Task FetchGeminiContent(string prompt)
        {
            var client = new HttpClient(); // establish http client connectionz

            string apiKey = Environment.GetEnvironmentVariable("GEMINI_API_KEY"); // setx api keys in terminal ex. setx API_KEY "duh key here"

            string url =
                $"https://generativelanguage.googleapis.com/v1beta/models/gemini-2.5-flash:generateContent?key={apiKey}";

            // this is the request that gemini expects (remember stucture)
            var requestBody = new
            {
                contents = new[]
                {
                    new
                    {
                        parts = new[]
                        {
                           new { text = prompt }
                        }
                    }
                }
            };

            var json = JsonSerializer.Serialize(requestBody); // serialize request body to json
            var content = new StringContent(json, Encoding.UTF8, "application/json"); // this tells the api we are sending json data

            var response = await client.PostAsync(url, content); // HERE is where we send the request to gemini
            var responseJson = await response.Content.ReadAsStringAsync(); // we wait for the response and read it as string

            if (!response.IsSuccessStatusCode) // check if successful 
            {
                Console.WriteLine("\nThe sadness Limit reached :(... we poor dowg!");
                Console.ReadKey();
            }

            var gemini = JsonSerializer.Deserialize<geminiResponse>(responseJson);

            if (gemini?.candidates == null || gemini.candidates.Length == 0) // check if not empty response
            {
                Console.WriteLine("\nSleepy head gemini...");
                Console.ReadKey();
            }

            Console.Clear();
            Console.WriteLine("RESPONSE: ");
            Console.WriteLine("\n" + gemini.candidates[0].content.parts[0].text + "\n");

            Start();

        }

    }
}


/*
    NOTES HERE:

    - Make sure to set your Gemini API key in the environment variables before running the application.
    - The application prompts the user for input, sends it to the Gemini API, and displays the response.
    - Error handling is included to manage unsuccessful responses and empty results.

Learned:
    - How to make HTTP POST requests in C# using HttpClient.
    - improved in serialize and deserialize JSON data using System.Text.Json.
    - How to set environment variables in terminal.
    - Basic structure of interacting with a generative language model API. (how to stucture models base on the response)

 */