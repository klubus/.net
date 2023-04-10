using ABC.BL;
using Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace CommonTest
{
    [TestClass]
    public class UslugaLogowanieTest
    {
        [TestMethod]
        public void PiszDoPlikuTest()
        {
            // Arrange
            var zmienioneElementy = new List<ILogowanie>();

            var klient = new Klient(1)
            {
                Email = "admin@dev-hobby.pl",
                Imie = "Mariusz",
                Nazwisko = "Kowal",
                ListaAdresow = null
            };
            zmienioneElementy.Add(klient as ILogowanie);

            var produkt = new Produkt(2)
            {
                NazwaProduktu = "Klocki",
                Opis = "Klocki do zabawy",
                AktualnaCena = 120M
            };
            zmienioneElementy.Add(produkt as ILogowanie);

            var zamowienie = new Zamowienie(3)
            {
                DataZamowienia = new DateTime(2018, 9, 21),
            };
            zmienioneElementy.Add(zamowienie as ILogowanie);

            // Act
            UslugaLogowanie.PiszDoPliku(zmienioneElementy);

            // Assert


        }
    }
}
