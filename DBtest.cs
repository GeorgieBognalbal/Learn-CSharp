using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutorialProject
{
    public class DBtest
    {
        public void dbConnection()
        {

            //Load env
            var userProfile = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            var envPath = Path.Combine(userProfile, @"source\repos\Learn-CSharp\.env");

            DotNetEnv.Env.Load(envPath);

            string user = Environment.GetEnvironmentVariable("user");
            string server = Environment.GetEnvironmentVariable("server");
            string database = Environment.GetEnvironmentVariable("database");
            string password = Environment.GetEnvironmentVariable("password");

            //String to give DB access
            string connectionStr = $"server={server}; database={database}; user={user}; password={password}";

            try
            {
                using (var connect = new MySqlConnection(connectionStr))
                {
                    Console.WriteLine("Loading Connection...");
                    connect.Open();
                    Console.WriteLine("Connected! Press any key to close");
                    Console.ReadKey();

                    connect.Close();
                    Console.WriteLine("Connection Closed!");
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
