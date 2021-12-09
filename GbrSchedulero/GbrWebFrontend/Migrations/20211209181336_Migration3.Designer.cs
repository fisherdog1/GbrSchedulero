﻿// <auto-generated />
using System;
using CHA.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CHA.Migrations
{
    [DbContext(typeof(FlightScheduleDbContext))]
    [Migration("20211209181336_Migration3")]
    partial class Migration3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.12");

            modelBuilder.Entity("GbrSchedulero.Aircraft", b =>
                {
                    b.Property<int>("AircraftID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("AcTypeAircraftTypeID")
                        .HasColumnType("int");

                    b.Property<string>("Registration")
                        .HasColumnType("text");

                    b.HasKey("AircraftID");

                    b.HasIndex("AcTypeAircraftTypeID");

                    b.ToTable("Aircrafts");
                });

            modelBuilder.Entity("GbrSchedulero.AircraftType", b =>
                {
                    b.Property<int>("AircraftTypeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("MaxPassengers")
                        .HasColumnType("int");

                    b.Property<string>("TypeName")
                        .HasColumnType("text");

                    b.HasKey("AircraftTypeID");

                    b.ToTable("AircraftTypes");
                });

            modelBuilder.Entity("GbrSchedulero.Airport", b =>
                {
                    b.Property<int>("AirportId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("AirportName")
                        .HasColumnType("text");

                    b.HasKey("AirportId");

                    b.ToTable("Airports");
                });

            modelBuilder.Entity("GbrSchedulero.AssignmentChangeOrder", b =>
                {
                    b.Property<int>("AssignmentChangeOrderID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("ChangeEffected")
                        .HasColumnType("datetime");

                    b.Property<int?>("CurrentAssignmentID")
                        .HasColumnType("int");

                    b.Property<int?>("PreviousAssignmentID")
                        .HasColumnType("int");

                    b.HasKey("AssignmentChangeOrderID");

                    b.HasIndex("CurrentAssignmentID")
                        .IsUnique();

                    b.HasIndex("PreviousAssignmentID")
                        .IsUnique();

                    b.ToTable("ChangeOrders");
                });

            modelBuilder.Entity("GbrSchedulero.CrewQualification", b =>
                {
                    b.Property<int>("CrewQualificationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("AcTypeAircraftTypeID")
                        .HasColumnType("int");

                    b.Property<int?>("CrewmemberID")
                        .HasColumnType("int");

                    b.Property<int>("Station")
                        .HasColumnType("int");

                    b.HasKey("CrewQualificationID");

                    b.HasIndex("AcTypeAircraftTypeID");

                    b.HasIndex("CrewmemberID");

                    b.ToTable("Qualifications");
                });

            modelBuilder.Entity("GbrSchedulero.Crewmember", b =>
                {
                    b.Property<int>("CrewmemberID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.HasKey("CrewmemberID");

                    b.ToTable("Crewmembers");
                });

            modelBuilder.Entity("GbrSchedulero.Flight", b =>
                {
                    b.Property<int>("FlightID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Passengers")
                        .HasColumnType("int");

                    b.Property<int?>("PlanFlightPlanID")
                        .HasColumnType("int");

                    b.Property<int?>("ShipAircraftID")
                        .HasColumnType("int");

                    b.HasKey("FlightID");

                    b.HasIndex("PlanFlightPlanID");

                    b.HasIndex("ShipAircraftID");

                    b.ToTable("Flights");
                });

            modelBuilder.Entity("GbrSchedulero.FlightCrewAssignment", b =>
                {
                    b.Property<int>("FlightCrewAssignmentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CrewmemberID")
                        .HasColumnType("int");

                    b.Property<int>("FlightID")
                        .HasColumnType("int");

                    b.HasKey("FlightCrewAssignmentID");

                    b.HasIndex("CrewmemberID");

                    b.HasIndex("FlightID");

                    b.ToTable("Assignments");
                });

            modelBuilder.Entity("GbrSchedulero.FlightPlan", b =>
                {
                    b.Property<int>("FlightPlanID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("ArrivalTime")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DepartureTime")
                        .HasColumnType("datetime");

                    b.Property<int>("DestinationID")
                        .HasColumnType("int");

                    b.Property<string>("FlightNumber")
                        .HasColumnType("text");

                    b.Property<int>("OriginID")
                        .HasColumnType("int");

                    b.HasKey("FlightPlanID");

                    b.HasIndex("DestinationID");

                    b.HasIndex("OriginID");

                    b.ToTable("FlightPlans");
                });

            modelBuilder.Entity("GbrSchedulero.Aircraft", b =>
                {
                    b.HasOne("GbrSchedulero.AircraftType", "AcType")
                        .WithMany()
                        .HasForeignKey("AcTypeAircraftTypeID");

                    b.Navigation("AcType");
                });

            modelBuilder.Entity("GbrSchedulero.AssignmentChangeOrder", b =>
                {
                    b.HasOne("GbrSchedulero.FlightCrewAssignment", "CurrentAssignment")
                        .WithOne("ChangeOrder")
                        .HasForeignKey("GbrSchedulero.AssignmentChangeOrder", "CurrentAssignmentID");

                    b.HasOne("GbrSchedulero.FlightCrewAssignment", "PreviousAssignment")
                        .WithOne()
                        .HasForeignKey("GbrSchedulero.AssignmentChangeOrder", "PreviousAssignmentID");

                    b.Navigation("CurrentAssignment");

                    b.Navigation("PreviousAssignment");
                });

            modelBuilder.Entity("GbrSchedulero.CrewQualification", b =>
                {
                    b.HasOne("GbrSchedulero.AircraftType", "AcType")
                        .WithMany()
                        .HasForeignKey("AcTypeAircraftTypeID");

                    b.HasOne("GbrSchedulero.Crewmember", null)
                        .WithMany("Qualifications")
                        .HasForeignKey("CrewmemberID");

                    b.Navigation("AcType");
                });

            modelBuilder.Entity("GbrSchedulero.Flight", b =>
                {
                    b.HasOne("GbrSchedulero.FlightPlan", "Plan")
                        .WithMany()
                        .HasForeignKey("PlanFlightPlanID");

                    b.HasOne("GbrSchedulero.Aircraft", "Ship")
                        .WithMany()
                        .HasForeignKey("ShipAircraftID");

                    b.Navigation("Plan");

                    b.Navigation("Ship");
                });

            modelBuilder.Entity("GbrSchedulero.FlightCrewAssignment", b =>
                {
                    b.HasOne("GbrSchedulero.Crewmember", "Crewmember")
                        .WithMany("Flights")
                        .HasForeignKey("CrewmemberID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GbrSchedulero.Flight", "Flight")
                        .WithMany("Crewmembers")
                        .HasForeignKey("FlightID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Crewmember");

                    b.Navigation("Flight");
                });

            modelBuilder.Entity("GbrSchedulero.FlightPlan", b =>
                {
                    b.HasOne("GbrSchedulero.Airport", "Destination")
                        .WithMany()
                        .HasForeignKey("DestinationID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GbrSchedulero.Airport", "Origin")
                        .WithMany()
                        .HasForeignKey("OriginID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Destination");

                    b.Navigation("Origin");
                });

            modelBuilder.Entity("GbrSchedulero.Crewmember", b =>
                {
                    b.Navigation("Flights");

                    b.Navigation("Qualifications");
                });

            modelBuilder.Entity("GbrSchedulero.Flight", b =>
                {
                    b.Navigation("Crewmembers");
                });

            modelBuilder.Entity("GbrSchedulero.FlightCrewAssignment", b =>
                {
                    b.Navigation("ChangeOrder");
                });
#pragma warning restore 612, 618
        }
    }
}
