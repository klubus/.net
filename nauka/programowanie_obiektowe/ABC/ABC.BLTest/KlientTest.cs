using ABC.BL;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ABC.BLTest
{
    [TestClass]
    public class KlientTest
    {
        [TestMethod]
        public void ImieNazwiskoTest()
        {
            // Arrange
            Klient klient = new Klient();
            klient.Imie = "Tomasz";
            klient.Nazwisko = "Nowak";
            string oczekiwana = "Tomasz, Nowak";

            // Act
            string aktualna = klient.ImieNazwisko;

            // Assert
            Assert.AreEqual(oczekiwana, aktualna);
        }

        [TestMethod]
        public void ImieNazwiskoImiePuste()
        {
            // Arrange
            Klient klient = new Klient();
            klient.Nazwisko = "Nowak";
            string oczekiwana = "Nowak";

            // Act
            string aktualna = klient.ImieNazwisko;

            // Assert
            Assert.AreEqual(oczekiwana, aktualna);
        }

        [TestMethod]
        public void ImieNazwiskoNazwiskoPuste()
        {
            // Arrange
            Klient klient = new Klient();
            klient.Imie = "Tomasz";
            string oczekiwana = "Tomasz";

            // Act
            string aktualna = klient.ImieNazwisko;

            // Assert
            Assert.AreEqual(oczekiwana, aktualna);
        }
    }
}
