using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GbrSchedulero
{
    abstract class Aircraft
    {
        private AircraftType type;

        public abstract AircraftType GetAircraftType();
        public abstract string GetRegistration();
    }
}
