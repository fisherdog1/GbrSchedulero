﻿using GbrSchedulero;
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

            //Crewmembers can have one or more qualifications
            builder.Entity<Crewmember>()
                .HasMany<CrewQualification>(c => c.qualifications)
                .WithOne();

            //Crew qualifications can be for one aircraft type
            builder.Entity<CrewQualification>()
                .HasOne<AircraftType>(cq => cq.AcType)
                .WithMany();

//<<<<<<< HEAD
//=======
            builder.Entity<FlightCrewAssignment>()
                .HasOne(fa => fa.Flight)
                .WithMany(f => f.Crewmembers)
                .HasForeignKey(fa => fa.FlightID);

            builder.Entity<AssignmentChangeOrder>()
                .HasOne<FlightCrewAssignment>(aco => aco.PreviousOrder)
                .WithOne(/**/) //Add something here so assignments can navigate to their relevant change order
                .HasForeignKey<AssignmentChangeOrder>(aco => aco.PreviousOrderID); 

            builder.Entity<AssignmentChangeOrder>()
                .HasOne<FlightCrewAssignment>(aco => aco.CurentOrder)
                .WithOne()
                .HasForeignKey<AssignmentChangeOrder>(aco => aco.CurrentOrderID);
//>>>>>>> 0186c1289abf5f0cb8f8fbcbb5efa0cffe69f8ec
        }

        public DbSet<AircraftType> AircraftTypes { get; set; }
        public DbSet<Airport> Airports { get; set; }
        public DbSet<Crewmember> Crewmembers { get; set; }
        public DbSet<CrewQualification> Qualifications { get; set; }
        public DbSet<Aircraft> Aircrafts { get; set; }
        public DbSet<FlightPlan> FlightPlans { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<FlightCrewAssignment> Assignments { get; set; }
        public DbSet<AssignmentChangeOrder> ChangeOrders { get; set; }
    }
}