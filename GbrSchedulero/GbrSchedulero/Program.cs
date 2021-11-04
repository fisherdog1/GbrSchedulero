using System;
using MySqlConnector;

namespace GbrSchedulero
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Provided DB Password: " + args[0]);
            DatabaseConnTest(args[0]);
        }

        public static int DatabaseConnTest(String dbPassword)
        {
            String connString = "server=gbrschedulero.c5vcx9th6rqh.us-east-2.rds.amazonaws.com;uid=admin;pwd={0};database=schedulero";

            MySqlConnection conn;

            try
            {
                conn = new MySqlConnection(String.Format(connString,dbPassword));
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
