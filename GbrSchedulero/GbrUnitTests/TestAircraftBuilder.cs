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
    /// </summary>
    class TestAircraftBuilder
    {
        public List<Aircraft> GenerateAircraft()
        {
            List<Aircraft> aircraft = new List<Aircraft>();

            AircraftType typeGR10 = AircraftType.GBR10();
            AircraftType typeN150 = AircraftType.NU150();

            Random r = new Random(1337);

            for (int i = 0; i < 21; i++)
            {
                int actype = r.Next(3);
                AircraftType typ;
                string reg;

                //Create about twice as many GR10 as NU150
                if (actype == 0)
                {
                    typ = typeN150;
                    reg = "CH"; //All NU150 registrations start with CH
                }
                else
                {
                    typ = typeGR10;
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
