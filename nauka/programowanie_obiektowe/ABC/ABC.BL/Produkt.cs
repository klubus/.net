using Common;
using System;

namespace ABC.BL
{
    public class Produkt : KlasaBazowa, ILogowanie
    {
        public Produkt()
        {

        }

        public Produkt(int produktId)
        {
            ProduktId = produktId;
        }

        public int ProduktId { get; private set; }
        public Decimal? AktualnaCena { get; set; }
        public string Opis { get; set; }
        private string _nazwaProduktu;

        public string NazwaProduktu
        {
            get
            {
                return _nazwaProduktu.WstawSpacje();
            }
            set { _nazwaProduktu = value; }
        }


        /// <summary>
        /// Pobieramy jeden produkt
        /// </summary>
        /// <param name="produktId"></param>
        /// <returns></returns>
        public Produkt Pobierz(int produktId)
        {
            // kod, który pobiera zdefiniowany produkt
            return new Produkt();
        }

        /// <summary>
        /// Zapisujemy bieżący produkt
        /// </summary>
        /// <param name="produktId"></param>
        /// <returns></returns>
        public bool Zapisz()
        {
            // kod, który zapisuje zdefiniowany produkt
            return true;
        }

        /// <summary>
        /// Sprawdzamy dane produktu
        /// </summary>
        /// <returns></returns>
        public override bool Zwaliduj()
        {
            var poprawne = true;

            if (string.IsNullOrWhiteSpace(NazwaProduktu))
                poprawne = false;

            return poprawne;
        }

        public override string ToString()
        {
            return NazwaProduktu;
        }

        public string Log()
        {
            var logTekst = ProduktId + ": " +
                           NazwaProduktu + " " +
                           "Opis: " + Opis + " " +
                           "Status: " + StanObiektu.ToString();
            return logTekst;
        }

    }

}
