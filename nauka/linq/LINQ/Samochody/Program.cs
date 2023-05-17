﻿using System;
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
                             select samochod;

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
