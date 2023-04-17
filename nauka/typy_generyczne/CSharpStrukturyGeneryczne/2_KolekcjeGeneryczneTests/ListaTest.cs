using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace _2_KolekcjeGeneryczneTests
{
    [TestClass]
    public class ListaTest
    {
        [TestMethod]
        public void ListaMozemyDodawacNaKoniec()
        {
            List<int> listaLiczb = new List<int> { 1, 2, 3 };
            listaLiczb.Add(4);

            Assert.AreEqual(4, listaLiczb[3]);
        }

        [TestMethod]
        public void ListaMozemyDodacNaPozycji()
        {
            List<int> listaLiczb = new List<int> { 1, 2, 3 };
            listaLiczb.Insert(1, 8);
            Assert.AreEqual(8, listaLiczb[1]);
        }

        [TestMethod]
        public void ListaMozemyUsuwacElement()
        {
            List<int> listaLiczb = new List<int> { 1, 2, 3 };
            listaLiczb.Remove(2);
            Assert.IsTrue(listaLiczb.SequenceEqual(new[] { 1, 3 }));
        }

        [TestMethod]
        public void ListaMozemyUsuwacElementNaPozycji()
        {
            List<int> listaLiczb = new List<int> { 1, 2, 3 };
            listaLiczb.RemoveAt(2);
            Assert.IsTrue(listaLiczb.SequenceEqual(new[] { 1, 2 }));
        }

        [TestMethod]
        public void ListaMozemyWyszukiwacIndex()
        {
            List<int> listaLiczb = new List<int> { 1, 2, 3 };
            Assert.AreEqual(listaLiczb.IndexOf(3), 2);
        }

        [TestMethod]
        public void ListaMozemyWyszukiwacCzyZawiera()
        {
            List<int> listaLiczb = new List<int> { 1, 2, 3 };
            Assert.AreEqual(listaLiczb.Contains(3), true);
        }

        [TestMethod]
        public void ListaMozemyDodawacNaKoniecZakesLiczb()
        {
            List<int> listaLiczb = new List<int> { 1, 2, 3 };
            var zakres = new List<int> { 4, 5, 6, 7 };
            listaLiczb.AddRange(zakres);

            Assert.AreEqual(7, listaLiczb[6]);
        }
    }
}
