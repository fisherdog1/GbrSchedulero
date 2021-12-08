using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GbrSchedulero
{
    public class Aircraft : IEquatable<Aircraft>
    {
        //Primary Key
        public int AircraftID { get; set; }
        public string Registration { get; private set; }
        public AircraftType AcType { get; private set; }

        public Aircraft(string registration, AircraftType acType)
        {
            this.Registration = registration;
            this.AcType = acType;
        }

        public bool Equals(Aircraft other)
        {
            return this.Registration == other.Registration;
        }
    }
}
