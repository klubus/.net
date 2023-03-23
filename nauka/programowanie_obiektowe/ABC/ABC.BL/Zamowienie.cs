using System;
using System.Collections.Generic;

namespace ABC.BL
{
    public class Zamowienie
    {
        public Zamowienie()
        {

        }

        public Zamowienie(int zamowienieId)
        {
            ZamowienieId = zamowienieId;
        }

        public int ZamowienieId { get; private set; }

        // DateTimeOffset wspomaga współpracę z różnymi strefami czasowymi
        public DateTimeOffset? DataZamowienia { get; set; }

        public List<PozycjaZamowienia> pozycjaZamowienia { get; set; }

        public int KlientId { get; set; }
        public int AdresDostawyId { get; set; }

        /// <summary>
        /// Pobieramy jedno zamowienie
        /// </summary>
        /// <param name="produktId"></param>
        /// <returns></returns>
        public Zamowienie Pobierz(int zamowienieId)
        {
            // kod, który pobiera zdefiniowane zamowienie
            return new Zamowienie();
        }

        /// <summary>
        /// Zapisujemy bieżące zamówienie
        /// </summary>
        /// <param name="produktId"></param>
        /// <returns></returns>
        public bool Zapisz()
        {
            // kod, który zapisuje zdefiniowane zamówienie
            return true;
        }

        /// <summary>
        /// Sprawdzamy dane zamówienia
        /// </summary>
        /// <returns></returns>
        public bool Zwaliduj()
        {
            var poprawne = true;

            if (DataZamowienia == null)
                poprawne = false;

            return poprawne;
        }

    }
}
