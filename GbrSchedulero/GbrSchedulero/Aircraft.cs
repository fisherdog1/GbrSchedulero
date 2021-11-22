using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GbrSchedulero
{
    public abstract class Aircraft
    {
        public string Registration { get; private set; }
        public AircraftType AcType { get; private set; }

        public Aircraft(string registration, AircraftType acType)
        {
            this.Registration = registration;
            this.AcType = acType;
        }
    }
}
