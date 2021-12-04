using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GbrSchedulero;
using MySql.Data.MySqlClient;
using Microsoft.Data.SqlClient;
using System.Reflection;
using System.Data;

namespace GbrSchedulero.CHA.Controllers
{
    public class CrewmemberController : Controller
    {
       
        public IActionResult Index()
        {
            List<GbrSchedulero.Crewmember> crewmembers = new List<GbrSchedulero.Crewmember>();
            //Connect to Mysql
            /*try {
                using (SqlConnection conn = new SqlConnection())
                {
                    String sql = @"select * from Crew";
                    conn.ConnectionString = @"server=localhost;user id=root;database=crewmems;persistsecurityinfo=True";
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = new SqlCommand(sql, conn);
                    da.Fill(dt);
                    foreach (DataRow row in dt.Rows)
                    {
                        var crew = new Crewmember();
                        crew.FirstName = row["FirstName"].ToString();
                        crew.LastName = row["LastName"].ToString();
                        crewmembers.Add(crew);

                    }
                }
                
                return View(crewmembers);
            }
            catch
            {
                return View("error");
            }*/
            using(MySqlConnection conn = new MySqlConnection("server=localhost;user=root;database=crewmems;persistsecurityinfo=True;password=nnguyen@123456789"))
            {
               
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select * from Crew", conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    //Extract data
                    Crewmember crewmember = new Crewmember();
                    crewmember.FirstName = reader["FirstName"].ToString();
                    crewmember.LastName = reader["LastName"].ToString();
                    crewmembers.Add(crewmember);

                }
                reader.Close();

            }
            return View(crewmembers);

        }
    }
}
