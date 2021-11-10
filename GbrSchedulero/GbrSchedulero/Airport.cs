using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GbrSchedulero
{
    abstract class Airport
    {
        public abstract string GetName();

        public abstract object GetDistance(Airport otherAirport);

    }
}
