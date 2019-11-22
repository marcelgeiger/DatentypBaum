using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Datentypen.Tests
{
    public class EinfacheVerkettetListeTest
    {
        [Test]
        public void TestAdd()
        {
            var liste = new EinfachVerketteteListe<int>();

            liste.Add(1);
            Assert.AreEqual(1, liste.Count);
            Assert.AreEqual(1, liste[0]);

            liste.Add(154);
            Assert.AreEqual(2, liste.Count);
            Assert.AreEqual(1, liste[0]);
            Assert.AreEqual(154, liste[1]);
        }

        [Test]
        public void Remove()
        {
            var liste = new EinfachVerketteteListe<int>();

            liste.Add(1);
            liste.Add(2);
            liste.Add(3);
            liste.Add(4);
            liste.Add(5);

            var removed = liste.Remove(25);
            Assert.AreEqual(false, removed);
            Assert.AreEqual(5, liste.Count);

            removed = liste.Remove(1);

            Assert.AreEqual(true, removed);
            Assert.AreEqual(4, liste.Count);
            Assert.AreEqual(2, liste[0]);


            removed = liste.Remove(5);

            Assert.AreEqual(true, removed);
            Assert.AreEqual(3, liste.Count);
            Assert.AreEqual(2, liste[0]);
            Assert.AreEqual(4, liste[2]);

            removed = liste.Remove(3);

            Assert.AreEqual(true, removed);
            Assert.AreEqual(2, liste.Count);
            Assert.AreEqual(2, liste[0]);
            Assert.AreEqual(4, liste[1]);

        }
    }
}
