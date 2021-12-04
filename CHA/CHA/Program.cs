using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CHA
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }
        public static int DatabaseConnTest(String connectionString)
        {
            MySqlConnection conn;

            try
            {
                conn = new MySqlConnection(connectionString);
                conn.Open();
            }
            catch (MySqlException)
            {
                Console.WriteLine("Db not connected");
                return 0;
            }

            Console.WriteLine("Db connected");

            MySqlCommand cmd = new MySqlCommand("select * from Test;", conn);
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine("Row: " + reader.GetString("testName"));
            }

            return 1;
        }

        /// <summary>
        /// Trivial function for testing unit test framework
        /// </summary>
        /// <returns>(int) 1</returns>
        public static int TrivialTestMethod()
        {
            return 1;
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
