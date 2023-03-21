using System;

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
        /// Zapisujemy bieżące zamówienie
        /// </summary>
        /// <param name="produktId"></param>
        /// <returns></returns>
        public bool Zapisz()
        {
            // kod, który zapisuje zdefiniowane zamówienie
            return true;
        }
    }
}
