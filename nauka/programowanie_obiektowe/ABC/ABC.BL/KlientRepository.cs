using System.Collections.Generic;

namespace ABC.BL
{
    public class KlientRepository
    {
        /// <summary>
        /// Zapisujemy obecnego klienta
        /// </summary>
        /// <returns></returns>
        /// 
        public bool Zapisz()
        {
            // kod, który zapisuje zdefiniowanego klienta
            return true;
        }


        /// <summary>
        /// Pobieramy jednego klienta
        /// </summary>
        /// <param name="klientId"></param>
        /// <returns></returns>
        public Klient Pobierz(int klientId)
        {
            //Tworzymy instancję klasy klienta
            Klient klient = new Klient(klientId);

            // kod, który pobiera określonego klienta

            // Tymczasowo zakodowane wartości, aby zwrócić klienta
            if (klientId == 1)
            {
                klient.Email = "marcin@dev-hobby.pl";
                klient.Imie = "Marcin";
                klient.Nazwisko = "Nowak";
            }

            return klient;
        }


        /// <summary>
        /// Pobieramy wszystkich klientów
        /// </summary>
        /// <returns></returns>
        public List<Klient> Pobierz()
        {
            // kod, który pobiera wszystkich klientów
            return new List<Klient>();
        }
    }
}
