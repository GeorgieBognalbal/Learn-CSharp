using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Linq;
using static TutorialProject.Weather.WeatherModel;

namespace TutorialProject.Weather
{
    public class GetWeather
    {
        public HttpClient client = new HttpClient();
        public WeatherModel weatherData = new WeatherModel();
        public async Task Display() 
        {

            // this is a dynamic way of getting file path
            var userProfile = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            var envPath = Path.Combine(userProfile, @"source\repos\Learn-CSharp\.env");

            DotNetEnv.Env.Load(envPath);

            var weatherAPI_key = Environment.GetEnvironmentVariable("WEATHER_API_KEY");

            Console.Write("Enter Location ex.(Liliw,ph): ");
            var location = Console.ReadLine().ToLower();

            string url = $"https://api.openweathermap.org/data/2.5/weather?q={location}&appid={weatherAPI_key}&units=metric";

            HttpClient client = new HttpClient();

            Console.Write("Loading");
            var loadingTask = Task.Run(async () =>
            {
                bool done = true;

                while (!done)
                {
                    Console.Write(".");
                    await Task.Delay(500);
                }
            });

            string response = await client.GetStringAsync(url); // sends the request and fires a response
            Console.Clear();
            Console.WriteLine("\nData received!");
                                                                                                                        // To make sure the any case work
            WeatherResponse weather = JsonSerializer.Deserialize<WeatherResponse>(response, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });       

            Console.WriteLine($"Teperature: {weather.Main.Temp}°C");
            Console.WriteLine($"Weather in {weather.Name}: {weather.Weather[0].Description}");

        }
    }
}



// NOTES HERE:
/*

this is the manual navigation of API response through .GetDocuments

string apiKey = "9dbe6104d433c7f13ae9f7564fa27f2d";

Console.Write("Enter Location ex.(Liliw,ph): ");
var location = Console.ReadLine().ToLower();

string url = $"https://api.openweathermap.org/data/2.5/weather?q={location}&appid={apiKey}&units=metric";

HttpClient client = new HttpClient();

            HttpResponseMessage response = await client.GetAsync(url); // sends the request and fires a response
response.EnsureSuccessStatusCode(); // ensure that response is received

string writtenResponse = await response.Content.ReadAsStringAsync(); // turns the response into string

JsonDocument doc = JsonDocument.Parse(writtenResponse);

var root = doc.RootElement;

               // navigating the response main{}   -GetProperty-> temp: diplay temp 
Console.WriteLine($"temp: {root.GetProperty("main").GetProperty("temp").GetDouble()}°C");

              // navigating the response weather index 0    -GetProperty-> Description: ex. Rain
Console.WriteLine($"Weather: {root.GetProperty("weather")[0].GetProperty("description").GetString()}");





// this is a dynamic way of getting file path
            var userProfile = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            var envPath = Path.Combine(userProfile, @"source\repos\Learn-CSharp\.env");
 


// ENV FILE - secure place to store keys
 */
