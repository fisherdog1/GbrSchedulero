using GbrSchedulero;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace CHA.Data
{
    public class FlightScheduleDbContext : DbContext
    {
        public FlightScheduleDbContext(DbContextOptions<FlightScheduleDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder dbco)
        {
            if (!dbco.IsConfigured)
            {
                //Configure database connection
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();

                var connectionString = configuration.GetConnectionString("Default");
                dbco.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //One Airport corresponds to multiple FlightPlan
            builder.Entity<FlightPlan>()
                .HasOne<Airport>(fp => fp.Origin)
                .WithMany();
            builder.Entity<FlightPlan>()
                .HasOne<Airport>(fp => fp.Destination)
                .WithMany();


        }

        public DbSet<AircraftType> AircraftTypes { get; set; }
        public DbSet<Airport> Airports { get; set; }
        public DbSet<Crewmember> Crewmembers { get; set; }
        public DbSet<Aircraft> Aircrafts { get; set; }
        public DbSet<FlightPlan> FlightPlans { get; set; }
        public DbSet<Flight> Flights { get; set; }
    }
}
