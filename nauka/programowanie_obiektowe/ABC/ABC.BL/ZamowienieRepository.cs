using System;
using System.Collections.Generic;

namespace ABC.BL
{
    public class ZamowienieRepository
    {

        /// <summary>
        /// Pobieramy jedno zamowienie
        /// </summary>
        /// <param name="produktId"></param>
        /// <returns></returns>
        public Zamowienie Pobierz(int zamowienieId)
        {
            // Tworzymy instancję klasy zamówienia i przekazujemy identyfikator
            Zamowienie zamowienie = new Zamowienie(zamowienieId);

            // kod, który pobiera zdefiniowane zamowienie

            // Tymczasowo zakodowane wartości zamówienia do zwrócenia
            if (zamowienieId == 10)
            {
                zamowienie.DataZamowienia = new DateTimeOffset(2018, 4, 14, 10, 00, 00, new TimeSpan(7, 0, 0));
            }
            return zamowienie;
        }

        /// <summary>
        /// Pobieramy jedno zamówienie do wyświetlenia
        /// </summary>
        /// <param name="zamowienieId"></param>
        /// <returns></returns>
        public WyswietlanieZamowienia PobierzZamowienieDoWyswietlenia(int zamowienieId)
        {
            WyswietlanieZamowienia wyswietlanieZamowienia = new WyswietlanieZamowienia();

            // kod, który pobiera zdefiniowane pola zamówienia

            // Tymczasowe zakodowane dane na stałe
            if (zamowienieId == 10)
            {
                wyswietlanieZamowienia.Imie = "Marcin";
                wyswietlanieZamowienia.Nazwisko = "Nowak";
                wyswietlanieZamowienia.DataZamowienia = new DateTimeOffset(2018, 4, 14, 10, 00, 00, new TimeSpan(7, 0, 0));
                wyswietlanieZamowienia.AdresDostawy = new Adres()
                {
                    AdresTyp = 1,
                    Ulica = "Koszmiczna",
                    Miasto = "Katowice",
                    KodPocztowy = "40-467",
                    Kraj = "Polska"
                };
            }

            wyswietlanieZamowienia.WyswietlaniePozycjiZamowieniaLista = new List<WyswietlaniePozycjiZamowienia>();

            // kod, który pobiera elementy zamówienia

            // Tymczasowe dane zakodowane na stałe
            if (zamowienieId == 10)
            {
                var wyswietlaniePozycjiZamowienia = new WyswietlaniePozycjiZamowienia()
                {
                    NazwaProduktu = "Krzesło",
                    IloscZamowienia = 4,
                    CenaZakupu = 199.77M
                };
                wyswietlanieZamowienia.WyswietlaniePozycjiZamowieniaLista.Add(wyswietlaniePozycjiZamowienia);

                wyswietlaniePozycjiZamowienia = new WyswietlaniePozycjiZamowienia()
                {
                    NazwaProduktu = "Stolik",
                    IloscZamowienia = 7,
                    CenaZakupu = 249M
                };
                wyswietlanieZamowienia.WyswietlaniePozycjiZamowieniaLista.Add(wyswietlaniePozycjiZamowienia);
            }
            return wyswietlanieZamowienia;
        }


        /// <summary>
        /// Zapisujemy bieżące zamówienie
        /// </summary>
        /// <param name="produktId"></param>
        /// <returns></returns>
        public bool Zapisz(Zamowienie zamowienie)
        {
            // kod, który zapisuje zdefiniowany produkt
            var suckes = true;

            if (zamowienie.MaZmiany && zamowienie.DaneSaPrawidlowe)
            {
                if (zamowienie.JestNowy)
                {
                    // wywołujemy procedure składowaną insert
                }
                else
                {
                    // wywołujemy procedure składowaną update
                }
            }

            return suckes;
        }
    }
}
