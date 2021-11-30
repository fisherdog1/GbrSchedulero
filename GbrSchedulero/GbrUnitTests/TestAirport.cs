using GbrSchedulero;
using Microsoft.VisualStudio.TestTools.UnitTesting;





namespace GbrUnitTests
{
    [TestClass]
    public class TestAirport
    {
        /// <summary>
        /// check that GetName methold in airport returns correct airport name 
        /// </summary>
        [TestMethod]
        public void AirportGetName_LincolnNebraska_retunLincolnAirport()
        {
            //Arrange
            Airport airport = new Airport(AirportName.LincolnNebraska);
            //Act
            string airportName = airport.GetName();
            //Assert
            Assert.AreEqual("Lincoln Airport", airportName);
        }

        /// <summary>
        /// check that GetDistance methold in airport returns 0 miles when geting distance between airport and it self
        /// example the distance between lincoln airport and lincoln airport is zero mile. 
        /// </summary>
        [TestMethod]
        public void AirportGetDistance_between_LincolnNebraska_and_LincolnNebraska_returns_zero()
        {
            //Arrange
            Airport airport = new Airport(AirportName.LincolnNebraska);
            //Act
            int airportDistance = airport.GetDistance(new Airport(AirportName.LincolnNebraska));
            //Assert
            Assert.AreEqual(0, airportDistance);
        }

        /// <summary>
        /// check that the distance between airport A to airport B is equal to the distance between airport B to airport A interchangeably  
        /// </summary>
        [TestMethod]
        public void AirportGetDistance_compute_distanceInterchangeably()
        {
            //Arrange
            Airport LincolnAirport = new Airport(AirportName.LincolnNebraska);
            Airport IowaAirport = new Airport(AirportName.IowaCityIowa);
            //Act
            int airportDistanceFromLincolnToIowa = LincolnAirport.GetDistance(IowaAirport);
            int airportDistanceFromIowaToLincoln = IowaAirport.GetDistance(LincolnAirport);

            //Assert
            Assert.AreEqual(airportDistanceFromLincolnToIowa, airportDistanceFromIowaToLincoln);
        }







    }
}

