using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Samochody
{
    public class Program
    {
        static void Main(string[] args)
        {
            var samochody = wczytywaniePliku2("C:/Users/kluba/Pulpit/dotnet/.net/nauka/linq/LINQ/Samochody/paliwo.csv");

            var zapytanie = samochody.OrderByDescending(s => s.SpalanieAutostrada)
                                     .ThenBy(s => s.Producent)
                                     .Select(s => s)
                                     .FirstOrDefault(s => s.Producent == "ccc" && s.Rok == 2018);

            var zapytanie2 = from samochod in samochody
                             where samochod.Producent == "Audi" && samochod.Rok == 2018
                             orderby samochod.SpalanieAutostrada descending, samochod.Producent ascending
                             select new
                             {
                                 samochod.Producent,
                                 samochod.Model,
                                 samochod.SpalanieAutostrada
                             };

            var zapytanie3 = samochody.Any(s => s.Producent == "BMW");
            var zapytanie4 = samochody.All(s => s.Producent == "BMW");
            var zapytanie5 = samochody.Contains(samochody[4]);
            var zapytanie6 = samochody.Contains<Samochod>(samochody[4]);

            Console.WriteLine(zapytanie3);
            Console.WriteLine(zapytanie4);
            Console.WriteLine(zapytanie5);
            Console.WriteLine(zapytanie6);

            if (zapytanie != null)
            {
                Console.WriteLine(zapytanie.Producent + " " + zapytanie.Model);
            }

            foreach (var item in zapytanie2.Take(10))
            {
                Console.WriteLine(item.Producent + " " + item.Model + " " + item.SpalanieAutostrada);
            }
            Console.ReadLine();
        }

        private static List<Samochod> wczytywaniePliku2(string sciezka)
        {
            var zapytanie = File.ReadAllLines(sciezka)
                                .Skip(1)
                                .Where(l => l.Length > 1)
                                .WSamochod();

            return zapytanie.ToList();
        }

        //private static List<Samochod> wczytywaniePliku(string sciezka)
        //{
        //    return File.ReadAllLines(sciezka)
        //               .Skip(1)
        //               .Where(linia => linia.Length > 1)
        //               .Select(Samochod.ParsujCSV).ToList();
        //}

    }

    public static class SamochodRozszerzenie
    {
        public static IEnumerable<Samochod> WSamochod(this IEnumerable<string> zrodlo)
        {
            foreach (var linia in zrodlo)
            {
                var kolumny = linia.Split(',');
                yield return new Samochod
                {
                    Rok = int.Parse(kolumny[0]),
                    Producent = kolumny[1],
                    Model = kolumny[2],
                    //Pojemnosc = double.Parse(kolumny[3]),
                    IloscCylindrow = int.Parse(kolumny[4]),
                    SpalanieMiasto = int.Parse(kolumny[5]),
                    SpalanieAutostrada = int.Parse(kolumny[6]),
                    SpalanieMieszane = int.Parse(kolumny[7]),
                };
            }
        }
    }
}
