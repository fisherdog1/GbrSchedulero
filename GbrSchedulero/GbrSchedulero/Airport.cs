using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GbrSchedulero
{
    /// <summary>
    /// Represents  Airport.
    /// </summary>
    public class Airport : IEquatable<Airport>
    {

        public string AirportName { get; set; }
        public int AirportId { get; set; }
     
        public Airport(string AirportName, int AirportId)
        {
            this.AirportName = AirportName;
            this.AirportId = AirportId;
        }

        public void setName(string name)
        {
            this.AirportName = name;
        }

        public void setId(int id)
        {
            this.AirportId = id;
        }


        public static Airport LincolnNebraska()
        {
            Airport airport = new Airport("Lincoln Airport", 0);
            return airport;
        }

        public static Airport IowaCityIowa()
        {
            Airport airport = new Airport("Easteren Iowa Airport", 1);
            return airport;
        }

        public static Airport EvanstonIllinois()
        {
            Airport airport = new Airport("O'Hare International Airport", 2);
            return airport;
        }

        public static Airport WestLafayetteIndiana()
        {
            Airport airport = new Airport("Purdue University Airport", 3);
            return airport;
        }

        public static Airport[] AllAirports()
        {
            return new Airport[] {
                new Airport("Lincoln Airport", 0),
                new Airport("Easteren Iowa Airport", 1),
                new Airport("O'Hare International Airport", 2),
                new Airport("Purdue University Airport", 3)};

        }

        /// <summary>
        /// a symmetric lookup table for distances between airports
        /// </summary>
        private static int[,] Airportdistance = new int[4, 4] { { 0, 272, 468, 608 },
                                                                { 272, 0, 193, 270 },
                                                                { 468, 193, 0, 119 },
                                                                { 608, 270, 119, 0 } };
        /// <summary>
        /// get Airport name 
        /// </summary>
        /// <returns>airportName</returns>
        public string GetName(){
            return AirportName;
        }
        /// <summary>
        /// get the distance in(miles) between the current airport and other airport 
        /// using a lookup table Airportdistance
        /// </summary>
        /// <returns>Airportdistance in miles</returns>
        public int GetDistance(Airport otherAirport) {
            int airportId = this.AirportId;
            int OtherAirportId = otherAirport.AirportId;
            return Airportdistance[airportId, OtherAirportId];
        }

        /// <summary>
        /// Compares airports based on their airportId.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(Airport other)
        {
            return this.AirportId == other.AirportId;
        }

        public override string ToString()
        {
            return AirportName;
        }
    }

  


}
