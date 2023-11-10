using NUnit.Framework;
using Sparky_Project;

namespace Sparky_NUnit_Test
{
    [TestFixture]
    public class CalculatorNUnitTests
    {
        [Test]
        public void AddNumbers_InputTwoInt_GetCorrectAddition()
        {
            //Arrange
            Calculator calculator = new Calculator();

            //Act
            int result = calculator.AddNumbers(10, 20);

            //Assert
            Assert.AreEqual(30, result);
        }

        [Test]
        public void IsOddChecker_InputEvenNumber_ReturnFalse()
        {
            //Arrange
            Calculator calculator = new Calculator();

            //Act
            int number = calculator.AddNumbers(10, 20);
            bool result = calculator.IsOddNumber(number);

            //Assert
            Assert.IsFalse(result);
        }

        [Test]
        [TestCase(11)]
        [TestCase(13)]
        public void IsOddChecker_InputOddNumber_ReturnTrue(int a)
        {
            //Arrange
            Calculator calculator = new Calculator();

            //Act
            int number = calculator.AddNumbers(a, 20);
            bool result = calculator.IsOddNumber(number);

            //Assert
            Assert.IsTrue(result);
        }

        [Test]
        [TestCase(10, ExpectedResult = false)]
        [TestCase(11, ExpectedResult = true)]
        public bool IsOddChecker_InputNumber_ReturnTrueIfOdd(int a)
        {
            Calculator calculator = new Calculator();
            return calculator.IsOddNumber(a);
        }

        [Test]
        [TestCase(5.4, 10.5)] // 15.9
        [TestCase(5.43, 10.53)] // 15.96
        [TestCase(5.49, 10.59)] // 16.08
        public void AddNumbersDouble_InputTwoDouble_GetCorrectAddition(double a, double b)
        {
            //Arrange
            Calculator calculator = new();

            //Act
            double result = calculator.AddNumbersDouble(a, b);

            //Assert
            Assert.AreEqual(15.9, result, .2);

        }

        [Test]
        public void OddRanger_InputMinAndMaxRange_ReturnsValidOddNumberRange()
        {
            Calculator calc = new Calculator();
            List<int> expectedOddRange = new() { 5, 7, 9 };
            List<int> result = calc.GetOddRange(5, 10);
            Assert.That(result, Is.EquivalentTo(expectedOddRange));
        }
    }
}
