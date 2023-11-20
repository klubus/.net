//namespace Sparky
//{
//    [TestFixture]
//    public class FiboXUnitTest
//    {
//        private Fibo fibo;
//        [SetUp]
//        public void SetUp()
//        {
//            fibo = new Fibo();
//        }
//        [Test]
//        public void GetFiboSeries_Input1_ResultMultiple()
//        {
//            fibo.Range = 1;
//            var result = fibo.GetFiboSeries();

//            Assert.That(result, Is.Not.Empty);
//            Assert.That(result, Is.Ordered);
//            Assert.That(result, Is.EqualTo(new List<int> { 0 }));
//        }

//        [Test]
//        public void GetFiboSeries_Input6_ResultMultiple()
//        {
//            fibo.Range = 6;
//            var result = fibo.GetFiboSeries();

//            Assert.That(result, Does.Contain(3));
//            Assert.That(result.Count, Is.EqualTo(6));
//            Assert.That(result, Does.Not.Contain(4));
//            Assert.That(result, Is.EqualTo(new List<int> { 0, 1, 1, 2, 3, 5 }));
//        }
//    }
//}
