using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecksSorter
{
    [TestFixture]
    public class Test
    {
        private DecksSorter sorter;

        [SetUp]
        public void SetUp()
        {
            sorter = new DecksSorter();
        }

        [Test]
        public void SorterCanAddAndDelete()
        {
            sorter.AddDeck("first");
            Assert.AreEqual(1, sorter.GetDecksNames().Count());
            Assert.AreEqual("first", sorter.GetDecksNames()[0]);
            sorter.DeleteDeck("first");
            Assert.AreEqual(0, sorter.GetDecksNames().Count());
        }

        [Test]
        public void SorterGetDeckAndNames()
        {
            sorter.AddDeck("first");
            sorter.AddDeck("second");
            Assert.IsTrue((new[] { "first", "second" }).SequenceEqual(sorter.GetDecksNames()));
            Assert.IsTrue((new Deck("first")).Equals(sorter.GetDeck("first")));
            Assert.IsTrue((new Deck("second")).Equals(sorter.GetDeck("second")));
        }

        [Test]
        public void SorterShuffleAndSortDecks()
        {
            sorter.AddDeck("first");
            sorter.ShuffleDeck("first");
            sorter.AddDeck("second");
            Assert.IsFalse(sorter.GetDeck("first").Cards.SequenceEqual(sorter.GetDeck("second").Cards));
            sorter.SortDeck("first");
            Assert.IsTrue(sorter.GetDeck("first").Cards.SequenceEqual(sorter.GetDeck("srcond").Cards));
        }
    }
}
