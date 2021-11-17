using GbrSchedulero;
using Microsoft.VisualStudio.TestTools.UnitTesting;





namespace GbrUnitTests
{
    [TestClass]
    public class TestAircraftType
    {
        /// <summary>
        /// checks that aircraft of type GBR-10 has 45 max passengers
        /// </summary>
        [TestMethod]
        public void AircraftType_GBR10_has_45_maxPassengers()
        {
            //Arrange
            AircraftType aircraft; 
            //Act
            aircraft = AircraftType.GBR10();
            //Assert
            Assert.AreEqual(45, aircraft.MaxPassengers);
        }
        /// <summary>
        /// checks that aircraft of type NU-150 has 75 max passengers
        /// </summary>
        [TestMethod]
        public void AircraftType_NU150_has_75_maxPassengers()
        {
            //Arrange
            AircraftType aircraft;
            //Act
            aircraft = AircraftType.NU150();
            //Assert
            Assert.AreEqual(75, aircraft.MaxPassengers);
        }


    }
}
