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
            firstNames = new List<string>();
            lastNames = new List<string>();

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

        /// <summary>
        /// Generate a random list of crewmembers
        /// </summary>
        /// <returns></returns>
        public List<Crewmember> GenerateCrews()
        {
            List<Crewmember> crewmembers = new List<Crewmember>();

            AircraftType typeGR10 = AircraftType.GBR10();
            AircraftType typeN150 = AircraftType.NU150();

            Random r = new Random(1337);

            for (int i = 0; i < 42; i++)
            {
                Crewmember crewmember = new Crewmember(
                    firstNames[r.Next(firstNames.Count)], 
                    lastNames[r.Next(lastNames.Count)]);

                int acType = r.Next(3);
                AircraftType ac;

                if (acType == 2)
                    ac = typeN150;
                else
                    ac = typeGR10;

                int crewType = r.Next(7);
                CrewStation cs;

                if (crewType >= 5)
                    cs = new CrewStation(StationType.Captain);
                else if (crewType >= 3)
                    cs = new CrewStation(StationType.Officer);
                else
                    cs = new CrewStation(StationType.Attendant);

                crewmember.AddQualification(new CrewQualification(cs, ac));
                crewmembers.Add(crewmember);
            }

            return crewmembers;
        }
    }
}
