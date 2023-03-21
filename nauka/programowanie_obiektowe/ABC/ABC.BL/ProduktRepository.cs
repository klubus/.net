namespace ABC.BL
{
    public class ProduktRepository
    {
        /// <summary>
        /// Pobieramy jeden produkt
        /// </summary>
        /// <param name="produktId"></param>
        /// <returns></returns>
        public Produkt Pobierz(int produktId)
        {
            // Tworzymy instancję klasy Produkt i przekazujemy identyfikator
            Produkt produkt = new Produkt(produktId);

            // kod, który pobiera zdefiniowany produkt

            // Tymczasowe zakodowane wartości, aby zwrócić produkt
            if (produktId == 2)
            {
                produkt.NazwaProduktu = "Klocki";
                produkt.Opis = "Klocki do zabawy dla dzieci powyżej 3 lat";
                produkt.AktualnaCena = 119.99M;

            }

            return produkt;
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
    }
}
