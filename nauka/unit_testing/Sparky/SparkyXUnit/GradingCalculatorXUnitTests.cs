using Sparky_Project;
using Xunit;

namespace Sparky
{
    public class GradingCalculatorXUnitTests
    {
        private GradingCalculator gradingCalculator;

        [Fact]
        public void CalculatorTest_InputScore95Attendance90_ReturnA()
        {
            // Arrange
            gradingCalculator = new GradingCalculator();
            gradingCalculator.Score = 95;
            gradingCalculator.AttendancePercentage = 90;

            // Act
            var result = gradingCalculator.GetGrade();

            // Assert
            Assert.Equal("A", result);
        }

        [Fact]
        public void CalculatorTest_InputScore85Attendance90_ReturnB()
        {
            // Arrange
            gradingCalculator = new GradingCalculator();
            gradingCalculator.Score = 85;
            gradingCalculator.AttendancePercentage = 90;

            // Act
            var result = gradingCalculator.GetGrade();

            // Assert
            Assert.Equal("B", result);
        }

        [Fact]
        public void CalculatorTest_InputScore65Attendance90_ReturnC()
        {
            // Arrange
            gradingCalculator = new GradingCalculator();
            gradingCalculator.Score = 65;
            gradingCalculator.AttendancePercentage = 90;

            // Act
            var result = gradingCalculator.GetGrade();

            // Assert
            Assert.Equal("C", result);
        }

        [Fact]
        public void CalculatorTest_InputScore95Attendance65_ReturnB()
        {
            // Arrange
            gradingCalculator = new GradingCalculator();
            gradingCalculator.Score = 95;
            gradingCalculator.AttendancePercentage = 65;

            // Act
            var result = gradingCalculator.GetGrade();

            // Assert
            Assert.Equal("B", result);
        }

        [Theory]
        [InlineData(95, 55)]
        [InlineData(65, 55)]
        [InlineData(50, 90)]
        public void CalculatorTest_InputScoreMultipleAttendanceMultiple_ReturnF(int score, int attendance)
        {
            // Arrange
            gradingCalculator = new GradingCalculator();
            gradingCalculator.Score = score;
            gradingCalculator.AttendancePercentage = attendance;

            // Act
            var result = gradingCalculator.GetGrade();

            // Assert
            Assert.Equal("F", result);
        }

        [Theory]
        [InlineData(95, 90, "A")]
        [InlineData(85, 90, "B")]
        [InlineData(65, 90, "C")]
        [InlineData(95, 65, "B")]
        [InlineData(95, 55, "F")]
        [InlineData(65, 55, "F")]
        [InlineData(50, 90, "F")]
        public void CalculatorTest_InputScoreMultipleAttendanceMultiple_ReturnMultiple(int score, int attendance, string expectedResult)
        {
            gradingCalculator = new GradingCalculator();
            gradingCalculator.Score = score;
            gradingCalculator.AttendancePercentage = attendance;

            var result = gradingCalculator.GetGrade();
            Assert.Equal(result, expectedResult);

        }
    }
}
