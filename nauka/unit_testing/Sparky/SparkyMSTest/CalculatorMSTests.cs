using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sparky_Project;

namespace SparkyMSTest
{
    [TestClass]
    public class CalculatorMSTests
    {
        [TestMethod]
        public void AddNumbers_InputTwoInt_GetCorrectAddition()
        {
            //Arrange
            Calculator calculator = new Calculator();

            //Act
            int result = calculator.AddNumbers(10, 20);

            //Assert
            Assert.AreEqual(30, result);
        }
    }
}
