using System;

namespace _1_TypyGeneryczne
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var kolejka = new KolejkaKolowa(pojemnosc: 5);

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

            kolejka.Zapisz("Marcin");

            var suma = 0.0;

            Console.WriteLine("W naszej kolejce jest :");

            while (!kolejka.JestPusty)
            {
                var wartosc = kolejka.Czytaj();
                if (wartosc is double)
                {
                    suma += (double)wartosc;
                }

            }
            Console.WriteLine(suma);

            Console.ReadKey();
        }
    }
}
