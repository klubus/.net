using ABC.BL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ABC.BLTest
{
    [TestClass]
    public class ZamowienieRepositoryTest
    {
        [TestMethod]
        public void PobierzZamowienie()
        {
            //Arrange
            ZamowienieRepository zamowienie = new ZamowienieRepository();
            var oczekiwana = new Zamowienie(10)
            {
                DataZamowienia = new DateTimeOffset(2018, 4, 14, 10, 00, 00, new TimeSpan(7, 0, 0))
            };

            //Act
            var aktualna = zamowienie.Pobierz(10);

            //Assert
            Assert.AreEqual(oczekiwana.DataZamowienia, aktualna.DataZamowienia);
        }
    }
}
