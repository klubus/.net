using System.Collections.Generic;

namespace ABC.BL
{
    public class Klient
    {
        public Klient()
        {

        }

        public Klient(int klientId)
        {
            KlientId = klientId;
        }

        public static int Licznik { get; set; }


        private string _nazwisko;

        public string Nazwisko
        {
            get
            {
                // tutaj dowolny kod
                return _nazwisko;
            }
            set
            {
                // tutaj dowolny kod
                _nazwisko = value;
            }
        }

        public string Imie { get; set; }

        public string Email { get; set; }

        public int KlientId { get; private set; }

        public string ImieNazwisko
        {
            get
            {
                string imieNazwisko = Imie;
                if (!string.IsNullOrWhiteSpace(Nazwisko))
                {
                    if (!string.IsNullOrWhiteSpace(imieNazwisko))
                    {
                        imieNazwisko += ", ";
                    }
                    imieNazwisko += Nazwisko;
                }
                return imieNazwisko;
            }
        }

        public bool Zwaliduj()
        {
            var poprawne = true;

            if (string.IsNullOrWhiteSpace(Nazwisko))
                poprawne = false;

            if (string.IsNullOrWhiteSpace(Email))
                poprawne = false;

            return poprawne;
        }

        /// <summary>
        /// Zapisujemy obecnego klienta
        /// </summary>
        /// <returns></returns>
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
            // kod, który pobiera określonego klienta
            return new Klient();
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
