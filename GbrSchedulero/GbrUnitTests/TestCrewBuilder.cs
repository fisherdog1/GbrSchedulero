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
    class TestCrewBuilder : ITestDataGenerator<Crewmember>
    {
        List<string> firstNames;
        List<string> lastNames;

        private AircraftType[] types;

        public TestCrewBuilder(AircraftType[] types)
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

            this.types = types;
            //Get names
        }

        /// <summary>
        /// Generate a random list of crewmembers
        /// </summary>
        /// <returns></returns>
        public List<Crewmember> Generate(int count)
        {
            List<Crewmember> crewmembers = new List<Crewmember>();

            Random r = new Random(1337*count);

            for (int i = 0; i < count; i++)
            {
                Crewmember crewmember = new Crewmember(
                    firstNames[r.Next(firstNames.Count)], 
                    lastNames[r.Next(lastNames.Count)]);

                int acType = r.Next(3);
                AircraftType ac;

                if (acType == 2)
                    ac = types[0];
                else
                    ac = types[1];

                StationType stationType;

                int a = r.Next(3);

                if (a == 2)
                    stationType = StationType.Captain;
                else if (a == 1)
                    stationType = StationType.Officer;
                else
                    stationType = StationType.Attendant;

                crewmember.AddQualification(new CrewQualification(stationType, ac));
                crewmembers.Add(crewmember);
            }

            return crewmembers;
        }

        
    }
}
