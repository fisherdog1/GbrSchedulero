using System;
using MySqlConnector;

namespace GbrSchedulero
{
    public class Program
    {
        static void Main(string[] args)
        {
        }

        public static int DatabaseConnTest(String connectionString)
        {
            MySqlConnection conn;

            try
            {
                conn = new MySqlConnection(connectionString);
                conn.Open();
            } catch (MySqlException e)
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
    }
}
