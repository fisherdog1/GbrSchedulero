using GbrSchedulero;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

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
            //
            builder.Entity<AircraftType>()
                .Property(act => act.Stations)
                .HasConversion(new StationsCoverter())
                .Metadata.SetValueComparer(new StationComparer());

            //One Airport corresponds to multiple FlightPlan
            builder.Entity<FlightPlan>()
                .HasOne<Airport>(fp => fp.Origin)
                .WithMany();

            builder.Entity<FlightPlan>()
                .HasOne<Airport>(fp => fp.Destination)
                .WithMany();

            //Crewmembers can have one or more qualifications
            builder.Entity<Crewmember>()
                .HasMany<CrewQualification>(c => c.Qualifications)
                .WithOne();

            //Crew qualifications can be for one aircraft type
            builder.Entity<CrewQualification>()
                .HasOne(cq => cq.AircraftType)
                .WithMany()
                .HasForeignKey(cq => cq.AircraftTypeID);

            builder.Entity<CrewQualification>()
                .HasOne(cq => cq.Crewmember)
                .WithMany(c => c.Qualifications)
                .HasForeignKey(cq => cq.CrewmemberID);

            builder.Entity<FlightCrewAssignment>()
                .HasOne(fa => fa.Flight)
                .WithMany(f => f.CrewAssignments)
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

        private bool HasOne<T>(System.Func<object, object> p)
        {
            throw new System.NotImplementedException();
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

    internal class StationComparer : ValueComparer<ICollection<StationType>>
    {
        public StationComparer() : base(
            (c1, c2) => c1.SequenceEqual(c2),
            c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())), c => (ICollection<StationType>)c.ToHashSet())
        {
        }
    }

    internal class StationsCoverter : ValueConverter<ICollection<StationType>, string>
    {
        public StationsCoverter() : base(
            v => JsonConvert.SerializeObject(v),
            v => JsonConvert.DeserializeObject<ICollection<StationType>>(v))
        {
        }
    }
}
