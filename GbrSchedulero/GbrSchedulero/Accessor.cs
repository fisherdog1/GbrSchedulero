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

        // Returns a flight given its flight number
        //public Flight GetFlight(string flightNumber)
        //{
        //    Flight flight = new Flight();
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

        //        MySqlCommand cmd = new MySqlCommand("Select * from Flight where flightNumber = @flightNumber;", conn);

        //        using (var reader = cmd.ExecuteReader())
        //        {
        //            while (reader.Read())
        //            {
        //                //grab all parameters of Crew, aircraftType, Aircraft, and Flight
        //                //make a Crew, AircraftType, and Aircraft and to construct a Flight
        //                //add to flight list

        //                //AircraftType type
        //                //Crewmember crew

        //                //string registrationNumber
        //                //Aircraft aircraft = new Aircraft(type, registrationNumber, crew);

        //                //string flightNumber
        //                //string origin
        //                //string destination
        //                //string scheduledTakeoff
        //                //string estimatedTakeoff
        //                //string actualTakeoff
        //                //string scheduledTouchdown
        //                //string estimatedTouchdown
        //                //string actualTouchdown
        //                //Flight flight = new Flight(flightNumber, aircraft, origin, destination, scheduledTakeoff, estimatedTakeoff, actualTakeoff, scheduledTouchdown, estimatedTouchdown, actualTouchdown);

        //            }
        //        }

        //        conn.Close();
        //    }
        //    return flight;
        //}


        // Returns an airport given its name

        // Returns a crew given a captain's name
        // Need to be able to make several crews given the amount of attendants

        //public Flight GetCrew(string FirstName)
        //{
        //    CrewStation crew = new CrewStation();
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

        //        MySqlCommand cmd = new MySqlCommand("Select * from Crew where captain = @FirstName;", conn);

        //        using (var reader = cmd.ExecuteReader())
        //        {
        //            while (reader.Read())
        //            {
        //                //need to get captain, first officer, attendants, type, qualifications, and aircraft type

        //                AircraftType aircraftType =

        //                Crewmember Captain =
        //                Crewmember Officer = 

        //                if(aircraftType = "GBR-10")
        //                {
        //                    Crewmember Attendant1 =
        //                    CrewStation crew = new CrewStation(StationType.Captain, StationType.Officer, StationType.Attendant, aircraftType);
        //                } else if(aircraftType = "NU-150")
        //                {
        //                    Crewmember Attendant1 =
        //                    Crewmember Attendant2 =
        //                    CrewStation crew = new CrewStation(StationType.Captain, StationType.Officer, StationType.Attendant, StationType.Attendant2, aircraftType);
        //                }

        //            }
        //        }

        //        conn.Close();
        //    }
        //    return crew;
        //}

        public void TestDataPull()
        {
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

                MySqlCommand cmd = new MySqlCommand("Select * from Test2;", connection);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine(reader[0] + ", ");
                        Console.Write(reader[1]);
                    }
                }
            }
        }
    }
}
