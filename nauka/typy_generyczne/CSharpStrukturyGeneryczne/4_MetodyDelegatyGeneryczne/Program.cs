using System;

namespace _4_MetodyDelegatyGeneryczne
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<double> drukuj = x => Console.WriteLine(x);
            drukuj(7.89);
            Action<int, int, int> test = (a, b, c) => Console.WriteLine(a + b + c);
            test(1, 2, 3);

            var kolejka = new KolejkaKolowa<double>();

            WprowadzanieDanych(kolejka);

            kolejka.Drukuj(d => Console.WriteLine(d));

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
