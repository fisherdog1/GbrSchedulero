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

        public string AirportName { get; private set; }
        public AirportName selectedAirport { get; private set; }
        public Airport(AirportName airportName)
        {
            this.selectedAirport = airportName;
            if (selectedAirport == GbrSchedulero.AirportName.LincolnNebraska)
            {
                this.AirportName = "Lincoln Airport";
            }
            else if (selectedAirport == GbrSchedulero.AirportName.IowaCityIowa)
            {
                this.AirportName = "Easteren Iowa Airport";
            }
            else if (selectedAirport == GbrSchedulero.AirportName.EvanstonIllinois)
            {
                this.AirportName = "O'Hare International Airport";
            }
            else if (selectedAirport == GbrSchedulero.AirportName.WestLafayetteIndiana)
            {
                this.AirportName = "Purdue University Airport";
            }

        }

        public static Airport[] AllAirports()
        {
            return new Airport[] { 
                new Airport(GbrSchedulero.AirportName.LincolnNebraska),
                new Airport(GbrSchedulero.AirportName.EvanstonIllinois),
                new Airport(GbrSchedulero.AirportName.IowaCityIowa),
                new Airport(GbrSchedulero.AirportName.WestLafayetteIndiana)};

        }

        /// <summary>
        /// a lookup table for distances between airports
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
            int i = (int)this.selectedAirport;
            int j = (int)otherAirport.selectedAirport;
            return Airportdistance[i,j];
        }

        /// <summary>
        /// Compares airports based on their name.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(Airport other)
        {
            return this.AirportName == other.AirportName;
        }

        public override string ToString()
        {
            return AirportName;
        }
    }

    /// <summary>
    /// Airports names of the covered region by the system
    /// </summary>
    public enum AirportName
    {
        LincolnNebraska,
        IowaCityIowa,
        EvanstonIllinois,
        WestLafayetteIndiana
    }


}
