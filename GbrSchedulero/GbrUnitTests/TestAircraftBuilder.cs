using GbrSchedulero;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GbrUnitTests
{
    /// <summary>
    /// Generates arbitrary aircraft
    /// Warning: Only actually supports an AircraftTypes list of two unique types.
    /// </summary>
    class TestAircraftBuilder : ITestDataGenerator<Aircraft>
    {
        private AircraftType[] types;
        public TestAircraftBuilder(AircraftType[] types)
        {
            this.types = types;
        }

        public List<Aircraft> Generate(int count)
        {
            List<Aircraft> aircraft = new List<Aircraft>();

            Random r = new Random(1337*count);

            for (int i = 0; i < count; i++)
            {
                int actype = r.Next(3);
                AircraftType typ;
                string reg;

                //Create about twice as many GR10 as NU150
                if (actype == 0)
                {
                    typ = types[0];
                    reg = "CH"; //All NU150 registrations start with CH
                }
                else
                {
                    typ = types[1];
                    reg = "CR"; //All GBR10 registrations start with CR
                }

                //Add 3 digits to registration
                reg += r.Next(0, 999).ToString("d3");

                Aircraft ac = new Aircraft(reg, typ);
                if (aircraft.Contains(ac)) //Don't add duplicate registration
                    continue;

                aircraft.Add(ac);
            }

            return aircraft;
        }
    }
}
