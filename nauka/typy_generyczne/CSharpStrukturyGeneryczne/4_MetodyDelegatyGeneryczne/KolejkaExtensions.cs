using System;
using System.Collections.Generic;

namespace _4_MetodyDelegatyGeneryczne
{
    public static class KolejkaExtensions
    {
        public delegate void Drukarka<T>(T dane);
        public static IEnumerable<Twyjscie> Mapuj<T, Twyjscie>(this IKolejka<T> kolejka, Converter<T, Twyjscie> konwerter)
        {

            foreach (var item in kolejka)
            {
                var wynik = konwerter(item);
                yield return (Twyjscie)wynik;
            }
        }

        public static void Drukuj<T>(this IKolejka<T> kolejka, Action<T> wydruk)
        {
            foreach (var item in kolejka)
            {
                wydruk(item);
            }
        }
    }
}
