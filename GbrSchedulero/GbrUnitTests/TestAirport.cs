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
            Airport airport = Airport.LincolnNebraska();
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
            Airport airport = Airport.LincolnNebraska();
            //Act
            int airportDistance = airport.GetDistance(Airport.LincolnNebraska());
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
            Airport LincolnAirport = Airport.LincolnNebraska();
            Airport IowaAirport = Airport.IowaCityIowa();
            //Act
            int airportDistanceFromLincolnToIowa = LincolnAirport.GetDistance(IowaAirport);
            int airportDistanceFromIowaToLincoln = IowaAirport.GetDistance(LincolnAirport);

            //Assert
            Assert.AreEqual(airportDistanceFromLincolnToIowa, airportDistanceFromIowaToLincoln);
        }


        /// <summary>
        /// checks that Equals method returns true when two airports have the same airportId 
        /// </summary>
        [TestMethod]
        public void AirportEquals_with_two_sameAirportId_ShouldReturnTrue()
        {
            //Arrange
            Airport LincolnAirport = Airport.LincolnNebraska();
            Airport LincolnAirportcopy = Airport.LincolnNebraska();

            //Act
            bool AreEquals = LincolnAirport.Equals(LincolnAirportcopy);
            //Assert
            Assert.AreEqual(true, AreEquals);
        }

        /// <summary>
        /// checks that Equals method returns false when two airports have different airportId
        /// </summary>
        [TestMethod]
        public void AirportEquals_with_two_differentAirportId_ShouldReturnFalse()
        {
            //Arrange
            Airport LincolnAirport = Airport.LincolnNebraska();
            Airport IowaAirport = Airport.IowaCityIowa();

            //Act
            bool AreEquals = LincolnAirport.Equals(IowaAirport);
            //Assert
            Assert.AreEqual(false, AreEquals);
        }






    }
}

