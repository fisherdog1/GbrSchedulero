using GbrSchedulero;
using Microsoft.VisualStudio.TestTools.UnitTesting;





namespace GbrUnitTests
{
    [TestClass]
    public class TestAircraft
    {
        /// <summary>
        /// checks that Equals method returns true when two aircrafts have the same registration data
        /// </summary>
        [TestMethod]
        public void AircraftEquals_with_two_sameRegistration_ShouldReturnTrue()
        {
            //Arrange
            Aircraft aircraft1 = new Aircraft("registration1", AircraftType.NU150());
            Aircraft aircraft2 = new Aircraft("registration1", AircraftType.NU150());

            //Act
            bool AreEquals = aircraft1.Equals(aircraft2);
            //Assert
            Assert.AreEqual(true, AreEquals);
        }

        /// <summary>
        /// checks that Equals method returns false when two aircrafts have different registration data
        /// </summary>
        [TestMethod]
        public void AircraftEquals_with_two_differentRegistration_ShouldReturnFalse()
        {
            //Arrange
            Aircraft aircraft1 = new Aircraft("registration1", AircraftType.NU150());
            Aircraft aircraft2 = new Aircraft("registration2", AircraftType.NU150());

            //Act
            bool AreEquals = aircraft1.Equals(aircraft2);
            //Assert
            Assert.AreEqual(false, AreEquals);
        }


    }
}
