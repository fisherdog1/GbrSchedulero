using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Interface for providing information about existing flight plans.
/// The implementing class should ensure up-to-dateness with the database when serving flight info, caching where appropriate.
/// </summary>
namespace GbrSchedulero
{
    interface IFlightPlanProvider
    {
        public Flight GetFlight(string flightNumber);
    }
}
