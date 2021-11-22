using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GbrSchedulero
{
    public abstract class Airport
    {
        public abstract string GetName();

        /// <summary>
        /// Return the distance to a neighboring airport in miles
        /// </summary>
        /// <param name="otherAirport"></param>
        /// <returns></returns>
        public abstract double GetDistance(Airport otherAirport);

    }
}
