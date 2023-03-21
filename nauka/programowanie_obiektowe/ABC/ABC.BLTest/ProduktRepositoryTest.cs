using ABC.BL;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ABC.BLTest
{
    [TestClass]
    public class ProduktRepositoryTest
    {
        [TestMethod]
        public void PobierzProdukt()
        {
            // Arrange
            var produktRepository = new ProduktRepository();
            var oczekiwana = new Produkt(2)
            {
                NazwaProduktu = "Klocki",
                Opis = "Klocki do zabawy dla dzieci powyżej 3 lat",
                AktualnaCena = 119.99M
            };

            // Act
            var aktualna = produktRepository.Pobierz(2);

            // Assert
            Assert.AreEqual(aktualna.NazwaProduktu, oczekiwana.NazwaProduktu);
            Assert.AreEqual(aktualna.Opis, oczekiwana.Opis);
            Assert.AreEqual(aktualna.AktualnaCena, oczekiwana.AktualnaCena);

        }
    }
}
