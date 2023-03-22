using ABC.BL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace ABC.BLTest
{
    [TestClass]
    public class KlientRepositoryTest
    {
        [TestMethod]
        public void PobierzKlienta()
        {
            // Arrange
            var klientRepository = new KlientRepository();
            var oczekiwana = new Klient(1)
            {
                Email = "marcin@dev-hobby.pl",
                Imie = "Marcin",
                Nazwisko = "Nowak"
            };

            // Act
            var aktualna = klientRepository.Pobierz(1);

            // Assert
            Assert.AreEqual(oczekiwana.Imie, aktualna.Imie);
            Assert.AreEqual(oczekiwana.Nazwisko, aktualna.Nazwisko);
            Assert.AreEqual(oczekiwana.KlientId, aktualna.KlientId);
            Assert.AreEqual(oczekiwana.Email, aktualna.Email);
        }

        [TestMethod]
        public void PobierzKlientaZAdresami()
        {
            // Arrange
            var klientRepository = new KlientRepository();
            var oczekiwana = new Klient(1)
            {
                Email = "marcin@dev-hobby.pl",
                Imie = "Marcin",
                Nazwisko = "Nowak",
                ListaAdresow = new List<Adres>()
                {
                    new Adres(1)
                    {
                         AdresTyp = 1,
                         Ulica = "Gościnna",
                         Miasto = "Katowice",
                         Kraj = "Polska",
                         KodPocztowy = "40-476"
                    },
                    new Adres(2)
                    {
                         AdresTyp = 2,
                         Ulica = "Kosmiczna",
                         Miasto = "Kraków",
                         Kraj = "Polska",
                         KodPocztowy = "22-321"
                    }
                }
            };

            // Act
            var aktualna = klientRepository.Pobierz(1);

            // Assert
            Assert.AreEqual(oczekiwana.Imie, aktualna.Imie);
            Assert.AreEqual(oczekiwana.Nazwisko, aktualna.Nazwisko);
            Assert.AreEqual(oczekiwana.KlientId, aktualna.KlientId);
            Assert.AreEqual(oczekiwana.Email, aktualna.Email);

            for (int i = 0; i < 1; i++)
            {
                Assert.AreEqual(oczekiwana.ListaAdresow[i].AdresTyp, aktualna.ListaAdresow[i].AdresTyp);
                Assert.AreEqual(oczekiwana.ListaAdresow[i].Ulica, aktualna.ListaAdresow[i].Ulica);
                Assert.AreEqual(oczekiwana.ListaAdresow[i].Miasto, aktualna.ListaAdresow[i].Miasto);
                Assert.AreEqual(oczekiwana.ListaAdresow[i].KodPocztowy, aktualna.ListaAdresow[i].KodPocztowy);
                Assert.AreEqual(oczekiwana.ListaAdresow[i].Kraj, aktualna.ListaAdresow[i].Kraj);
            }
        }
    }
}
