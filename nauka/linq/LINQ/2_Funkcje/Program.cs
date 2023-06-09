﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace _2_Funkcje
{
    public class Program
    {
        static void Main(string[] args)
        {
            Func<int, int> potegowanie = x => x * x;
            Func<int, int, int> dodawanie = (a, b) => a + b;

            Action<int> wypisz = x => Console.WriteLine(x);

            wypisz(potegowanie(dodawanie(1, 2)));

            var programisci = new Pracownik[]
            {
                new Pracownik {Id = 1, Imie="Marcin", Nazwisko="Nowak"},
                new Pracownik {Id = 2, Imie="Tomek", Nazwisko="Kowal"},
                new Pracownik {Id = 3, Imie="Jacek", Nazwisko="Sobota"},
                new Pracownik {Id = 4, Imie="Adam", Nazwisko="Wrona"}
            };

            var kierowcy = new List<Pracownik>()
            {
                new Pracownik {Id = 5, Imie="Olek", Nazwisko ="Sroka"},
                new Pracownik {Id = 6, Imie="Pawel", Nazwisko ="Wrobel"},
                new Pracownik {Id = 7, Imie="Marek", Nazwisko ="Piatek"},
            };

            //ExtensionMethods(programisci, kierowcy);
            //IEnumerable(kierowcy);

            var zapytanie = programisci.Where(p => p.Imie.Length == 5)
                                             .OrderByDescending(p => p.Imie)
                                             .Select(p => p);

            var zapytanie2 = from programista in programisci
                             where programista.Imie.Length == 5
                             orderby programista.Imie descending
                             select programista;
            var ilosc = zapytanie2.Count();

            foreach (var osoba in zapytanie2)
            {
                Console.WriteLine(osoba.Imie);
            }

            Console.ReadKey();
        }

        private static void ExtensionMethods(IEnumerable<Pracownik> programisci, IEnumerable<Pracownik> kierowcy)
        {
            Console.WriteLine(programisci.Count());
            Console.WriteLine(kierowcy.Count());
        }

        private static void IEnumerable(IEnumerable<Pracownik> kierowcy)
        {
            IEnumerator<Pracownik> enumerator = kierowcy.GetEnumerator();

            while (enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current.Imie);
            }
        }
    }
}
