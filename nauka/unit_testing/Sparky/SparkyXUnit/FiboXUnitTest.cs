using Sparky_Project;
using Xunit;

namespace Sparky
{
    public class FiboXUnitTest
    {
        private Fibo fibo;
        public FiboXUnitTest()
        {
            fibo = new Fibo();
        }

        [Fact]
        public void GetFiboSeries_Input1_ResultMultiple()
        {
            fibo.Range = 1;
            var result = fibo.GetFiboSeries();

            Assert.NotEmpty(result);
            //Assert.That(result, Is.Ordered);
            Assert.Equal(result.OrderBy(u => u), result);

            Assert.Equal(new List<int> { 0 }, result);
        }

        [Fact]
        public void GetFiboSeries_Input6_ResultMultiple()
        {
            fibo.Range = 6;
            var result = fibo.GetFiboSeries();

            Assert.Contains(3, result);
            Assert.Equal(6, result.Count);
            Assert.DoesNotContain(4, result);
            Assert.Equal(new List<int> { 0, 1, 1, 2, 3, 5 }, result);
        }
    }
}
