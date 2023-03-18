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

        [TestMethod]
        public void StaticTest()
        {
            // Arrange
            Klient klient1 = new Klient();
            klient1.Imie = "Tomasz";
            Klient.Licznik += 1;


            Klient klient2 = new Klient();
            klient2.Imie = "Jacek";
            Klient.Licznik += 1;


            Klient klient3 = new Klient();
            klient3.Imie = "Marek";
            Klient.Licznik += 1;

            //Assert
            Assert.AreEqual(3, Klient.Licznik);

        }

        [TestMethod]
        public void ZwalidujTest()
        {
            // Arrange
            var klient = new Klient();
            klient.Nazwisko = "Nowak";
            klient.Email = "tomek@dev-hobby.pl";
            var oczekiwana = true;

            // Act
            var aktualna = klient.Zwaliduj();

            // Assert
            Assert.AreEqual(oczekiwana, aktualna);
        }

        [TestMethod]
        public void ZwalidujBrakNazwiska()
        {
            // Arrange
            var klient = new Klient();
            klient.Email = "tomek@dev-hobby.pl";
            var oczekiwana = false;

            // Act
            var aktualna = klient.Zwaliduj();

            // Assert
            Assert.AreEqual(oczekiwana, aktualna);
        }
    }
}
