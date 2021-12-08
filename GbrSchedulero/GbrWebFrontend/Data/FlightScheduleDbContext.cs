using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CHA.Data
{
    public class FlightScheduleDbContext: DbContext
    {
        public FlightScheduleDbContext(DbContextOptions<FlightScheduleDbContext> options): base(options)
        {

        }
        public FlightScheduleDbContext()
        {

        }
        public DbSet<Crewmem> crewmems { get; set; }

        

    }
}
