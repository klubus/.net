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
            var samochody = WczytywanieSamochodu("C:/Users/kluba/Pulpit/dotnet/.net/nauka/linq/LINQ/Samochody/paliwo.csv");
            var producenci = WczytywanieProducenci("C:/Users/kluba/Pulpit/dotnet/.net/nauka/linq/LINQ/Samochody/producent.csv");

            var zapytanie = from samochod in samochody
                            join producent in producenci on samochod.Producent equals producent.Nazwa
                            orderby samochod.SpalanieAutostrada descending, samochod.Producent ascending
                            select new
                            {
                                samochod.Producent,
                                samochod.Model,
                                producent.Siedziba,
                                samochod.SpalanieAutostrada
                            };


            foreach (var samochod in zapytanie.Take(10))
            {
                Console.WriteLine(samochod.Siedziba + " " + samochod.Producent + " " + samochod.Model + " " + samochod.SpalanieAutostrada);
            }
            Console.ReadLine();
        }

        private static List<Samochod> WczytywanieSamochodu(string sciezka)
        {
            var zapytanie = File.ReadAllLines(sciezka)
                                .Skip(1)
                                .Where(l => l.Length > 1)
                                .WSamochod();

            return zapytanie.ToList();
        }

        private static List<Producent> WczytywanieProducenci(string sciezka)
        {
            var zapytanie = File.ReadAllLines(sciezka)
                                .Skip(1)
                                .Where(l => l.Length > 1)
                                .Select(l =>
                                {
                                    var kolumny = l.Split(',');
                                    return new Producent
                                    {
                                        Nazwa = kolumny[0],
                                        Siedziba = kolumny[1],
                                        Rok = int.Parse(kolumny[2])
                                    };
                                });

            return zapytanie.ToList();
        }

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