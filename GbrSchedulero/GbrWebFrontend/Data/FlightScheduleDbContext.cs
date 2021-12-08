using GbrSchedulero;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CHA.Data
{
    public class FlightScheduleDbContext: DbContext
    {
        public FlightScheduleDbContext(DbContextOptions<FlightScheduleDbContext> options) : base(options)
        {

        }

        public FlightScheduleDbContext()
        {

        }

        public DbSet<Crewmember> Crewmembers { get; set; }
        public DbSet<Aircraft> Aircrafts { get; set; }
        public DbSet<FlightPlan> FlightPlans { get; set; }
        public DbSet<Flight> Flights { get; set; }
    }
}
