using System.Collections.Generic;
using System.Linq;

namespace ABC.BL
{
    public class KlientRepository
    {
        private AdresRepository adresRepository { get; set; }

        public KlientRepository()
        {
            adresRepository = new AdresRepository();
        }
        /// <summary>
        /// Zapisujemy obecnego klienta
        /// </summary>
        /// <returns></returns>
        /// 
        public bool Zapisz(Klient klient)
        {
            // kod, który zapisuje zdefiniowany produkt
            var suckes = true;

            if (klient.MaZmiany && klient.DaneSaPrawidlowe)
            {
                if (klient.JestNowy)
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


        /// <summary>
        /// Pobieramy jednego klienta
        /// </summary>
        /// <param name="klientId"></param>
        /// <returns></returns>
        public Klient Pobierz(int klientId)
        {
            //Tworzymy instancję klasy klienta
            Klient klient = new Klient(klientId);
            klient.ListaAdresow = adresRepository.PobierzPoKlientId(klientId).ToList();

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
