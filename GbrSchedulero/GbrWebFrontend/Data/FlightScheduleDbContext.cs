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
                .WithMany()
                .HasForeignKey("AircraftTypeID");

            builder.Entity<Flight>()
                .HasOne<Aircraft>(fl => fl.Ship)
                .WithMany()
                .HasForeignKey("AircraftID");

            builder.Entity<Flight>()
                .HasOne<FlightPlan>(fl => fl.Plan)
                .WithMany()
                .HasForeignKey("FlightPlanID");

            builder.Entity<FlightCrewAssignment>()
                .HasKey(fa => fa.FlightCrewAssignmentID);

            builder.Entity<FlightCrewAssignment>()
                .HasOne(fa => fa.Crewmember)
                .WithMany(c => c.Flights)
                .HasForeignKey(fa => fa.CrewmemberID);

            builder.Entity<FlightCrewAssignment>()
                .HasOne(fa => fa.Flight)
                .WithMany(f => f.Crewmembers)
                .HasForeignKey(fa => fa.FlightID);

            builder.Entity<AssignmentChangeOrder>()
                .HasOne<FlightCrewAssignment>(aco => aco.PreviousAssignment)
                .WithOne()
                .HasForeignKey<AssignmentChangeOrder>(aco => aco.PreviousAssignmentID); 

            builder.Entity<AssignmentChangeOrder>()
                .HasOne<FlightCrewAssignment>(aco => aco.CurrentAssignment)
                .WithOne(a => a.ChangeOrder)
                .HasForeignKey<AssignmentChangeOrder>(aco => aco.CurrentAssignmentID);
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
