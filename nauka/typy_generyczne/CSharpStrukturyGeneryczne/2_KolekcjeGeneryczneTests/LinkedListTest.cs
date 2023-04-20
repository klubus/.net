using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace _2_KolekcjeGeneryczneTests
{
    [TestClass]
    public class LinkedListTest
    {
        [TestMethod]
        public void DodawaniePoElemencie()
        {
            var lista = new LinkedList<string>();
            lista.AddFirst("Marcin");
            lista.AddLast("Tomek");
            lista.AddAfter(lista.First, "Ola");

            Assert.AreEqual("Ola", lista.First.Next.Value);
        }

        [TestMethod]
        public void DodawaniePrzedElementem()
        {
            var lista = new LinkedList<string>();
            lista.AddFirst("Marcin");
            lista.AddLast("Tomek");
            lista.AddBefore(lista.First, "Ola");

            Assert.AreEqual("Ola", lista.First.Value);
        }

        [TestMethod]
        public void UsuwanieElementuOstatniego()
        {
            var lista = new LinkedList<string>();
            lista.AddFirst("Marcin");
            lista.AddLast("Tomek");
            lista.RemoveLast();

            Assert.AreEqual(lista.First, lista.Last);
        }

        [TestMethod]
        public void UsuwanieElementu()
        {
            var lista = new LinkedList<string>();
            lista.AddFirst("Marcin");
            lista.AddLast("Tomek");
            lista.Remove("Marcin");

            Assert.AreEqual("Tomek", lista.Last.Value);
        }

        [TestMethod]
        public void CzyListaZawieraElement()
        {
            var lista = new LinkedList<string>();
            lista.AddFirst("Marcin");
            lista.AddLast("Tomek");

            Assert.IsTrue(lista.Contains("Tomek"));
        }

        [TestMethod]
        public void CzyszczenieListy()
        {
            var lista = new LinkedList<string>();
            lista.AddFirst("Marcin");
            lista.AddLast("Tomek");
            lista.Clear();

            Assert.AreEqual(0, lista.Count);
        }
    }
}
