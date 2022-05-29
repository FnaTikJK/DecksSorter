using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecksSorter
{
    public class Deck
    {
        public List<Card> Cards { get; private set; }
        public readonly string Name;

        public Deck(string name, int cardsCount = 52)
        {
            Name = name;
            Cards = new List<Card>(cardsCount);
            FillDeck(cardsCount);
        }

        private void FillDeck(int cardsCount)
        {
            var countRanks = Enum.GetNames(typeof(Rank)).Count();
            var countSuits = Enum.GetNames(typeof(Suit)).Count();

            for (int i = countRanks - cardsCount / countSuits; i < countRanks; i++)
                for (int j = 0; j < countSuits; j++)
                    Cards.Add(new Card((Suit)j, (Rank)i));
        }

        public void Shuffle(ShuffleOption option)
        {
            switch (option)
            {
                case ShuffleOption.EmulateHuman: HumanShuffle(); break;
                default: SimpleShuffle(); break;
            }
        }

        private void SimpleShuffle()
        {
            var rnd = new Random();
            for(int i = Cards.Count() - 1; i>=0;i--)
            {
                var newInd = rnd.Next(0, i);
                var temp = Cards[newInd];
                Cards[newInd] = Cards[i];
                Cards[i] = temp;
            }
        }

        private void HumanShuffle()
        {
            var itterationsCount = new Random().Next(3, 10);
            for(int i = 0; i < itterationsCount; i++)
            {
                var firstStack = new Stack<Card>(Cards.GetRange(0,Cards.Count/2));
                var secondStack = new Stack<Card>
                    (Cards.GetRange(Cards.Count() / 2, Cards.Count() - Cards.Count() / 2));

                var ind = Cards.Count()-1;
                while(firstStack.Count > 0 || secondStack.Count > 0)
                {
                    Cards[ind--] = firstStack.Pop();
                    Cards[ind--] = secondStack.Pop();
                }
            }
        }

        public void Sort()
        {
            Cards.Sort();
        }

        public override bool Equals(object? obj)
        {
            var other = obj as Deck;
            if (other == null) return false;
            if (Name == other.Name && Cards.SequenceEqual(other.Cards)) return true;
            return false;
        }
    }
}
