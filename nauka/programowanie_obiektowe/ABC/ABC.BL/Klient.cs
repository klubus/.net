using System.Collections.Generic;

namespace ABC.BL
{
    public class Klient
    {
        public Klient() : this(0)
        {

        }

        public Klient(int klientId)
        {
            KlientId = klientId;
            ListaAdresow = new List<Adres>();
        }

        public List<Adres> ListaAdresow { get; set; }

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

        public int KlientTyp { get; set; }

        public bool Zwaliduj()
        {
            var poprawne = true;

            if (string.IsNullOrWhiteSpace(Nazwisko))
                poprawne = false;

            if (string.IsNullOrWhiteSpace(Email))
                poprawne = false;

            return poprawne;
        }

    }
}
