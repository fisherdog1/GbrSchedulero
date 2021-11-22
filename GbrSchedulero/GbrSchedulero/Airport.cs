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
    public class Airport
    {

        private string airportName { get;}
        public AirportName selectedAirport { get; private set; }
        public Airport(AirportName airportName)
        {
            this.selectedAirport = airportName;
            if (selectedAirport == AirportName.LincolnNebraska)
            {
                this.airportName = "Lincoln Airport";

            }
            else if (selectedAirport == AirportName.IowaCityIowa)
            {
                this.airportName = "Easteren Iowa Airport";
            }
            else if (selectedAirport == AirportName.EvanstonIllinois)
            {
                this.airportName = "O'Hare International Airport";
            }
            else if (selectedAirport == AirportName.WestLafayetteIndiana)
            {
                this.airportName = "Purdue University Airport";
            }

        }
        /// <summary>
        /// a lookup table for distances between airports
        /// </summary>
        int[,] Airportdistance = new int[4, 4] { { 0, 272, 468, 608 },
                                           { 272, 0, 193, 270 },
                                           { 468, 193, 0, 119 },
                                           { 608, 270, 119, 0 } };
        /// <summary>
        /// get Airport name 
        /// </summary>
        /// <returns>airportName</returns>
        public string GetName(){
            return airportName;
        }
        /// <summary>
        /// get the distance in(miles) between the currtent airport  and other airpot 
        /// using a lookup table Airportdistance
        /// </summary>
        /// <returns>Airportdistance in miles</returns>
        public int GetDistance(Airport otherAirport) {
            int i = (int)this.selectedAirport;
            int j = (int)otherAirport.selectedAirport;
            return Airportdistance[i,j];
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
