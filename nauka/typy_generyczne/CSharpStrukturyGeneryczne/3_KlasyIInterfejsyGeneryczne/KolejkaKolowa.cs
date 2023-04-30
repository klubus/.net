namespace _3_KlasyIInterfejsyGeneryczne
{
    public class KolejkaKolowa<T> : IKolejka<T>
    {
        private T[] bufor;
        private int pocztekBufora;
        private int koniecBufora;

        public KolejkaKolowa() : this(pojemnosc: 5)
        {
        }

        public KolejkaKolowa(int pojemnosc)
        {
            bufor = new T[pojemnosc + 1];
            pocztekBufora = 0;
            koniecBufora = 0;
        }

        public void Zapisz(T wartosc)
        {
            bufor[koniecBufora] = wartosc;
            koniecBufora = (koniecBufora + 1) % bufor.Length;

            if (koniecBufora == pocztekBufora)
                pocztekBufora = (pocztekBufora + 1) % bufor.Length;
        }

        public T Czytaj()
        {
            var wynik = bufor[pocztekBufora];
            pocztekBufora = (pocztekBufora + 1) % bufor.Length;
            return wynik;
        }

        public int Pojemnosc
        {
            get
            {
                return bufor.Length;
            }
        }

        public bool JestPusty
        {
            get
            {
                return koniecBufora == pocztekBufora;
            }
        }

        public bool JestPelny
        {
            get
            {
                return (koniecBufora + 1) % bufor.Length == pocztekBufora;
            }
        }
    }
}
