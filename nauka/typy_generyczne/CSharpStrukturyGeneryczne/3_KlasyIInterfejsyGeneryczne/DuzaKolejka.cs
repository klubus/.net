using System.Collections.Generic;

namespace _3_KlasyIInterfejsyGeneryczne
{
    public class DuzaKolejka<T> : IKolejka<T>
    {

        Queue<T> kolejka;
        public DuzaKolejka()
        {
            kolejka = new Queue<T>();
        }

        public bool JestPelny => throw new System.NotImplementedException();

        public bool JestPusty
        {
            get
            {
                return kolejka.Count == 0;
            }
        }

        public T Czytaj()
        {
            return kolejka.Dequeue();
        }

        public void Zapisz(T wartosc)
        {
            kolejka.Enqueue(wartosc);
        }
    }
}