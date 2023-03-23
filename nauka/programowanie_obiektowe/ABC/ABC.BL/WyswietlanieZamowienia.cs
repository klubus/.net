using System;
using System.Collections.Generic;

namespace ABC.BL
{
    public class WyswietlanieZamowienia
    {
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public DateTimeOffset? DataZamowienia { get; set; }
        public List<WyswietlaniePozycjiZamowienia> WyswietlaniePozycjiZamowieniaLista { get; set; }
        public int ZamowienieId { get; set; }
        public Adres AdresDostawy { get; set; }
    }
}
