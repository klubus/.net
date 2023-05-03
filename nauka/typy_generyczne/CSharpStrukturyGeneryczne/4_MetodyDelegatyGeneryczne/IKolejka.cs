using System.Collections.Generic;

namespace _4_MetodyDelegatyGeneryczne
{
    public interface IKolejka<T> : IEnumerable<T>
    {
        bool JestPelny { get; }
        bool JestPusty { get; }

        T Czytaj();
        void Zapisz(T wartosc);
    }
}