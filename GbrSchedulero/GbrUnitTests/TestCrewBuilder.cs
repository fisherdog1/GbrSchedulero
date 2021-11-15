using GbrSchedulero;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GbrUnitTests
{
    /// <summary>
    /// Builds arbitrary Crewmembers
    /// </summary>
    class TestCrewBuilder
    {
        List<string> firstNames;
        List<string> lastNames;

        public TestCrewBuilder()
        {
            //Import JSON of test names
            string ass = Assembly.GetExecutingAssembly().Location;
            string dir = Path.GetDirectoryName(ass);
            string path = Path.Combine(dir, @"Data\test_names.json");

            using (JsonTextReader jtr = new JsonTextReader(File.OpenText(path)))
            {
                JToken current = JToken.ReadFrom(jtr).First;

                do
                {
                    string firstName = current.SelectToken("firstName").Value<string>();
                    string lastName = current.SelectToken("lastName").Value<string>();

                    firstNames.Add(firstName);
                    lastNames.Add(lastName);

                    current = current.Next;
                } while (current.Next != null);
            }

            //Get names
        }

        //public List<Crewmember> GenerateCrews()
        //{

        //}
    }
}
