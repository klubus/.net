using NUnit.Framework;
using Sparky_Project;

namespace Sparky_NUnit_Test
{
    [TestFixture]
    public class GradingCalculatorNUnitTests
    {
        private GradingCalculator gradingCalculator;
        [SetUp]
        public void SetUp()
        {
            gradingCalculator = new GradingCalculator();
        }

        [Test]
        public void CalculatorTest_InputScore95Attendance90_ReturnA()
        {
            // Arrange
            gradingCalculator.Score = 95;
            gradingCalculator.AttendancePercentage = 90;

            // Act
            var result = gradingCalculator.GetGrade();

            // Assert
            Assert.That(result, Is.EqualTo("A"));
        }

        [Test]
        public void CalculatorTest_InputScore85Attendance90_ReturnB()
        {
            // Arrange
            gradingCalculator.Score = 85;
            gradingCalculator.AttendancePercentage = 90;

            // Act
            var result = gradingCalculator.GetGrade();

            // Assert
            Assert.That(result, Is.EqualTo("B"));
        }

        [Test]
        public void CalculatorTest_InputScore65Attendance90_ReturnC()
        {
            // Arrange
            gradingCalculator.Score = 65;
            gradingCalculator.AttendancePercentage = 90;

            // Act
            var result = gradingCalculator.GetGrade();

            // Assert
            Assert.That(result, Is.EqualTo("C"));
        }

        [Test]
        public void CalculatorTest_InputScore95Attendance65_ReturnB()
        {
            // Arrange
            gradingCalculator.Score = 95;
            gradingCalculator.AttendancePercentage = 65;

            // Act
            var result = gradingCalculator.GetGrade();

            // Assert
            Assert.That(result, Is.EqualTo("B"));
        }

        [Test]
        [TestCase(95, 55)]
        [TestCase(65, 55)]
        [TestCase(50, 90)]
        public void CalculatorTest_InputScoreMultipleAttendanceMultiple_ReturnF(int score, int attendance)
        {
            // Arrange
            gradingCalculator.Score = score;
            gradingCalculator.AttendancePercentage = attendance;

            // Act
            var result = gradingCalculator.GetGrade();

            // Assert
            Assert.That(result, Is.EqualTo("F"));
        }

        [Test]
        [TestCase(95, 90, ExpectedResult = "A")]
        [TestCase(85, 90, ExpectedResult = "B")]
        [TestCase(65, 90, ExpectedResult = "C")]
        [TestCase(95, 65, ExpectedResult = "B")]
        [TestCase(95, 55, ExpectedResult = "F")]
        [TestCase(65, 55, ExpectedResult = "F")]
        [TestCase(50, 90, ExpectedResult = "F")]
        public string CalculatorTest_InputScoreMultipleAttendanceMultiple_ReturnMultiple(int score, int attendance)
        {
            gradingCalculator.Score = score;
            gradingCalculator.AttendancePercentage = attendance;

            var result = gradingCalculator.GetGrade();
            return result;
        }
    }
}
