namespace _4_MetodyDelegatyGeneryczne
{
    public class KolejkaKolowa<T> : DuzaKolejka<T>
    {
        private int _pojemnosc;

        public KolejkaKolowa(int pojemnosc = 5)
        {
            _pojemnosc = pojemnosc;
        }

        public override void Zapisz(T wartosc)
        {
            base.Zapisz(wartosc);

            if (kolejka.Count > _pojemnosc)
            {
                kolejka.Dequeue();
            }
        }

        public override bool JestPelny
        {
            get
            {
                return kolejka.Count == _pojemnosc;
            }
        }
    }

}
