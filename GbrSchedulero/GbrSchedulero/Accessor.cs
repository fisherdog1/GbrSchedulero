using System;
using System.Collections.Generic;
using MySqlConnector;


namespace GbrSchedulero
{
    //Used to take any data needed from database
    class Accessor
    {
        public static string connectionString;

        /* Things to access:
         *  - Flights
         *  - Airports
         *  - Aircrafts
         *  - Crew Members
         *  - Crew Stations
         */
        //TODO: Figure out if connection is correct
        //TODO: Look at using statements and use connection instead of conn

        // Returns a list of all flights
        public static List<Flight> GetFlights()
        {

            List<Flight> Flights = new List<Flight>();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                // TODO: dont need conn, use connection
                try
                {
                    connection.Open();

                }
                catch (MySqlException e)
                {
                    throw new Exception("DATABASE NOT CONNECTED", e);
                }

                MySqlCommand cmd = new MySqlCommand("Select * from Flight;", connection);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        //grab all parameters of Crew, aircraftType, Aircraft, and Flight
                        //make a Crew, AircraftType, and Aircraft and to construct a Flight
                        //add to flight list

                        //AircraftType type
                        //Crewmember crew

                        //string registrationNumber
                        //Aircraft aircraft = new Aircraft(type, registrationNumber, crew);

                        //string flightNumber
                        //string origin
                        //string destination
                        //string scheduledTakeoff
                        //string estimatedTakeoff
                        //string actualTakeoff
                        //string scheduledTouchdown
                        //string estimatedTouchdown
                        //string actualTouchdown
                        //Flight flight = new Flight(flightNumber, aircraft, origin, destination, scheduledTakeoff, estimatedTakeoff, actualTakeoff, scheduledTouchdown, estimatedTouchdown, actualTouchdown);

                        //Flights.Add(flight);
                    }
                }

                connection.Close();
            }

            return Flights;
        }

        // Returns a list of all airports
        public List<Airport> GetAirports()
        {
            List<Airport> Airports = new List<Airport>();
            List<Flight> Flights = new List<Flight>();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {

                try
                {
                    connection.Open();

                }
                catch (MySqlException e)
                {
                    throw new Exception("DATABASE NOT CONNECTED", e);
                }

                MySqlCommand cmd = new MySqlCommand("Select * from Airport;", connection);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        //Grab all parameters of airport
                        //use getflights to get list of flights
                        //make airport and add to airports list

                        //List<Flight> Flights = GetFlights();

                        //CrewStation standby
                        //FlightPlan flightplan
                        //Airport airport = new Airport(Flights, flightPlan, standby);
                        //airports.Add(airport);
                    }
                }

                connection.Close();
            }

            return Airports;
        }

        // Returns a list of all crews
        //Need a way to identify different crews
        //public string GetCrews() { }

        // Returns an aircraft given its registration number
        //TODO: Figure out how to create an aircraft, change it within the using statement, and return it

        //public Aircraft GetAircraft(string registrationNumber)
        //{
        //    Aircraft aircraft = new Aircraft();
        //    using (MySqlConnection connection = new MySqlConnection(connectionString))
        //    {
        //        MySqlConnection conn;
        //        try
        //        {
        //            conn = new MySqlConnection(connectionString);
        //            conn.Open();

        //        }
        //        catch (MySqlException e)
        //        {
        //            throw new Exception("DATABASE NOT CONNECTED", e);
        //        }

        //        MySqlCommand cmd = new MySqlCommand("Select * from Aircraft where registrationNumber = @registrationNumber;", conn);

        //        using (var reader = cmd.ExecuteReader())
        //        {
        //            while (reader.Read())
        //            {

        //                //AircraftType type
        //                //Aircraft aircraft = new Aircraft(type, registrationNumber);
        //            }
        //        }

        //        conn.Close();
        //    }

        //    return aircraft;
        //}

        //Returns a flight given its flight number
        //public Flight GetFlight(string flightNumber)
        //{
        //    Flight flight = new Flight();
        //    using (MySqlConnection connection = new MySqlConnection(connectionString))
        //    {
        //        try
        //        {
        //            connection.Open();

        //        }
        //        catch (MySqlException e)
        //        {
        //            throw new Exception("DATABASE NOT CONNECTED", e);
        //        }

        //        MySqlCommand cmd = new MySqlCommand("select * from Flight f " +
        //            "join Aircraft a on f.aircraftID = a.aircraftID " +
        //            "join AircraftType a_t on a.aircraftTypeID = a_t.aircraftTypeID " +
        //            "join Crew c on a_t.crewId = c.crewId " +
        //            "where flightNumber = @flightNumber;", connection);

        //        using (var reader = cmd.ExecuteReader())
        //        {
        //            while (reader.Read())
        //            {
        //                //grab all parameters of Crew, aircraftType, Aircraft, and Flight
        //                //make a Crew, AircraftType, and Aircraft and to construct a Flight
        //                //add to flight list

        //                int passengers = 0;
        //                string nameOf = reader.GetString("typeName");
        //                if (nameOf.Equals("GBR-10"))
        //                    passengers = 45;
        //                else if (nameOf.Equals("NU-150"))
        //                    passengers = 75;

        //                AircraftType typeName = new AircraftType(nameOf, passengers);

        //                string registrationNumber = reader.GetString("registrationNumber");
        //                Aircraft aircraft = new Aircraft(registrationNumber, typeName);

                        
        //                //Crewmember captain = ;
        //                //Crewmember firstOfficer = ;

        //                //if (nameOf.Equals("GBR-10"))
        //                //{
        //                //    Crewmember Attendant1 = ;
        //                //    Crewmember[] crew = new Crewmember[] {captain, firstOfficer, Attendant1};
        //                //}
        //                //else if (nameOf.Equals("NU-150"))
        //                //{
        //                //    Crewmember Attendant1 = ;
        //                //    Crewmember Attendant2 = ;
        //                //    Crewmember[] crew = new Crewmember[] {captain, firstOfficer, Attendant1, Attendant2};
        //                //}

        //                string origin = reader.GetString("originAirport");
        //                Airport originAirport = FindAirport(origin);

        //                string destination = reader.GetString("destinationAirport");
        //                Airport destinationAirport = FindAirport(destination);

        //                string takeoffTime = reader.GetString("scheduledTakeoff");
        //                DateTime scheduledTakeoff = Convert.ToDateTime(takeoffTime);

        //                string touchdownTime = reader.GetString("scheduledTouchdown");
        //                DateTime scheduledTouchdown = Convert.ToDateTime(touchdownTime);

        //                string estimatedTakeoff = reader.GetString("estimatedTakeoff");
        //                string actualTakeoff = reader.GetString("actualTakeoff");
        //                string estimatedTouchdown = reader.GetString("estimatedTouchdown");
        //                string actualTouchdown = reader.GetString("actualTouchdown");

        //                //find a way to find origin and destination airports
        //                FlightPlan plan = new FlightPlan(flightNumber, originAirport, destinationAirport, scheduledTakeoff, scheduledTouchdown);

        //                Flight flight = new Flight(plan, aircraft, passengers, crew);

        //            }
        //        }

        //        connection.Close();
        //    }
        //    return flight;
        //}

        // Need to be able to make several crews given the amount of attendants
        public Crewmember[] GetCrew()
        {
            Crewmember[] crew = new Crewmember[] { };

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                }
                catch (MySqlException e)
                {
                    throw new Exception("DATABASE NOT CONNECTED", e);
                }

                MySqlCommand cmd = new MySqlCommand("select * from Aircraft a " +
                    "join AircraftType a_t on a.aircraftTypeId = a_t.aircraftTypeID " +
                    "join Crew c on a.crewId = c.crewId " +
                    "join CrewMember cm on c.memberId = cm.memberId; ", connection);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        int passengers = 0;
                        string nameOf = reader.GetString("typeName");
                        if (nameOf.Equals("GBR-10"))
                            passengers = 45;
                        else if (nameOf.Equals("NU-150"))
                            passengers = 75;

                        AircraftType typeName = new AircraftType(nameOf, passengers);

                        //create crew
                        //Crewmember captain = ;
                        //Crewmember firstOfficer = ;

                        //crew[0] = captain;
                        //crew[1] = firstOfficer;

                        //if (nameOf.Equals("GBR-10"))
                        //{
                        //    Crewmember Attendant1 = ;
                        //    crew[2] = Attendant1;
                        //}   
                        //else if (nameOf.Equals("NU-150"))
                        //{
                        //    Crewmember Attendant1 = ;
                        //    Crewmember Attendant2 = ;
                        //    crew[2] = Attendant1;
                        //    crew[3] = Attendant2;
                        //}

                    }
                }

                connection.Close();
            }
            return crew;
        }

        // Deletes all data from database
        public void ClearTables()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                
                try
                {
                    connection.Open();

                }
                catch (MySqlException e)
                {
                    throw new Exception("DATABASE NOT CONNECTED", e);
                }

                MySqlCommand cmd = new MySqlCommand("Truncate table Airport; Truncate table Flight; Truncate table Aircraft; Truncate table AircraftType; " +
                    "Truncate table Crew; Truncate table CrewMember;", connection);
                
            }
            
        }


        public Airport FindAirport(string name)
        {
            
            Airport airport = new Airport(name, 999);

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {

                try
                {
                    connection.Open();

                }
                catch (MySqlException e)
                {
                    throw new Exception("DATABASE NOT CONNECTED", e);
                }

                MySqlCommand cmd = new MySqlCommand("Select * from Airport where airportId = @airportId;", connection);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        //Grab all parameters of airport

                        int id = reader.GetInt32("airportId");
                        airport.setId(id);
                        
                    }
                }

                connection.Close();
            }
            return airport;
        }
    }
}
