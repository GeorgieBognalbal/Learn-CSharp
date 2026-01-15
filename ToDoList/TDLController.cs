using System;
using System.IO;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using SQLite;

namespace TutorialProject.ToDoList
{
    public class TDLController
    {
        public async Task dbConnection()
        {
            var userProfile = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            var envPath = Path.Combine(userProfile, @"source\repos\Learn-CSharp\.env");

            DotNetEnv.Env.Load(envPath);

            string user = Environment.GetEnvironmentVariable("user");
            string server = Environment.GetEnvironmentVariable("server");
            string database = Environment.GetEnvironmentVariable("database");
            string password = Environment.GetEnvironmentVariable("password");


            string connectionStr = $"server={server}; database={database}; user={user}; password={password}";

            try
            {
                using (var connect = new MySqlConnection(connectionStr))
                {
                    Console.WriteLine("Loading Connection...");
                    connect.Open();
                    Console.WriteLine("Connected! Press any key to close");
                    Console.ReadKey();

                    
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"AN ERROR OCCURRED: {ex.Message}");
            }
        }
    }
}
