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

            foreach (var item in samochody)
            {
                Console.WriteLine(item.Producent + " " + item.Model);
            }
            Console.ReadLine();
        }

        private static List<Samochod> wczytywaniePliku2(string sciezka)
        {
            var zapytanie = (from linia in File.ReadAllLines(sciezka).Skip(1)
                             where linia.Length > 1
                             select Samochod.ParsujCSV(linia));
            return zapytanie.ToList();
        }

        private static List<Samochod> wczytywaniePliku(string sciezka)
        {
            return File.ReadAllLines(sciezka)
                       .Skip(1)
                       .Where(linia => linia.Length > 1)
                       .Select(Samochod.ParsujCSV).ToList();
        }

    }
}
