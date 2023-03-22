using System.Collections.Generic;

namespace ABC.BL
{
    public class AdresRepository
    {


        /// <summary>
        /// Pobieramy jeden adres
        /// </summary>
        /// <param name="adresId"></param>
        /// <returns></returns>
        public Adres Pobierz(int adresId)
        {
            // Tworzymy instancję klasy Adres i przekazujemy żądany identyfikator
            Adres adres = new Adres(adresId);

            // kod, który pobiera określonego klienta

            // Tymczasowo zakodowane wartości, aby zwrócić klienta
            if (adresId == 1)
            {
                adres.AdresTyp = 1;
                adres.Ulica = "Gościnna";
                adres.Miasto = "Katowice";
                adres.Kraj = "Polska";
                adres.KodPocztowy = "40-467";
            }
            return adres;
        }

        /// <summary>
        /// Pobieramy wszystkie zdefiniowane adresy dla klienta
        /// </summary>
        /// <param name="klientId"></param>
        /// <returns></returns>
        public IEnumerable<Adres> PobierzPoKlientId(int klientId)
        {
            // Kod, który zdefiniowane adresy dla klienta

            // Tymczasowo zakodowane wartości do zwrócenia, zestaw adresów dla klienta
            var adresList = new List<Adres>();

            Adres adres = new Adres(1)
            {
                AdresTyp = 1,
                Ulica = "Gościnna",
                Miasto = "Katowice",
                Kraj = "Polska",
                KodPocztowy = "40-476"
            };
            adresList.Add(adres);

            adres = new Adres(2)
            {
                AdresTyp = 2,
                Ulica = "Kosmiczna",
                Miasto = "Kraków",
                Kraj = "Polska",
                KodPocztowy = "22-321"
            };
            adresList.Add(adres);

            return adresList;
        }

        /// <summary>
        /// Zapisujemy aktualny adres
        /// </summary>
        /// <returns></returns>
        /// 
        public bool Zapisz(Adres adres)
        {
            // kod, który zapisuje zdefiniowany adres
            return true;
        }
    }
}
