using System;

namespace _1_TypyGeneryczne
{
    class Program
    {
        static void Main(string[] args)
        {
            var kolejka = new KolejkaKolowa<double>(pojemnosc: 3);
            var kolejkaInt = new KolejkaKolowa<int>();
            var kolejkaString = new KolejkaKolowa<string>(1000);
            var kolejkaOsob = new KolejkaKolowa<Osoba>();
            kolejkaOsob.Zapisz(new Osoba { Imie = "Marcin", Nazwisko = "Nowak" });
            kolejkaOsob.Zapisz(new Osoba { Imie = "Tomek", Nazwisko = "Nowak" });
            kolejkaOsob.Zapisz(new Osoba { Imie = "Kacper", Nazwisko = "Nowak" });
            kolejkaOsob.Zapisz(new Osoba { Imie = "Marcin", Nazwisko = "Nowak" });

            while (!kolejkaOsob.JestPusty)
            {
                var wynik = kolejkaOsob.Czytaj().Imie;
                Console.WriteLine(wynik);
            };

            /*
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

            var suma = 0.0;
            Console.WriteLine("W naszej kolejce jest :");

            while (!kolejka.JestPusty)
            {
                suma += kolejka.Czytaj();
            }
            Console.WriteLine(suma);
            */
            Console.ReadKey();

        }
    }
    public class Osoba
    {
        public string Imie { get; set; }
        public string Nazwisko { get; set; }

    }
}
