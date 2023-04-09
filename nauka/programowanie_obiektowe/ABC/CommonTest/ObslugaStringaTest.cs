using Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CommonTest
{
    [TestClass]
    public class ObslugaStringaTest
    {
        [TestMethod]
        public void WstawSpacjeTest()
        {
            //Arange
            var zrodlo = "KlockiLego";
            var oczekiwana = "Klocki Lego";

            //Act
            var aktualna = zrodlo.WstawSpacje();

            //Assert
            Assert.AreEqual(oczekiwana, aktualna);
        }

        [TestMethod]
        public void WstawSpacjeTestZeSpacja()
        {
            //Arange
            var zrodlo = "Klocki Lego";
            var oczekiwana = "Klocki Lego";

            //Act
            var aktualna = zrodlo.WstawSpacje();

            //Assert
            Assert.AreEqual(oczekiwana, aktualna);
        }
    }
}