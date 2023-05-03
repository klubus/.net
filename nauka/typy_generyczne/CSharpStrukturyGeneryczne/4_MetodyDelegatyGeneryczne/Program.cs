using System;
using static _4_MetodyDelegatyGeneryczne.KolejkaExtensions;

namespace _4_MetodyDelegatyGeneryczne
{
    class Program
    {
        static void KonsolaWypisz(double dane)
        {
            Console.WriteLine(dane);
        }

        static void Main(string[] args)
        {


            var kolejka = new KolejkaKolowa<double>();
            WprowadzanieDanych(kolejka);

            var KonsolaWyjscie = new Drukarka<double>(KonsolaWypisz);

            kolejka.Drukuj(KonsolaWypisz);

            PrzetwarzanieDanych(kolejka);

            Console.ReadKey();

        }

        private static void PrzetwarzanieDanych(IKolejka<double> kolejka)
        {
            var suma = 0.0;
            Console.WriteLine("W naszej kolejce jest :");

            while (!kolejka.JestPusty)
            {
                suma += kolejka.Czytaj();
            }
            Console.WriteLine(suma);
        }

        private static void WprowadzanieDanych(IKolejka<double> kolejka)
        {
            while (true)
            {
                var wartosc = 0.0;
                var wartoscWejsciowa = Console.ReadLine();

                if (double.TryParse(wartoscWejsciowa, out wartosc))
                {
                    kolejka.Zapisz(wartosc);
                    continue;
                }
                break;
            }
        }
    }
}
