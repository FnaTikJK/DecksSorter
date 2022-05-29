using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecksSorter
{
    public class DecksSorter
    {
        public LinkedList<Deck> Decks { get; set; }
        //линкедлист, тк эффективнее в данной реализации

        public DecksSorter()
        {
            Decks = new LinkedList<Deck>();
        }

        public void AddDeck(string deckName, int cardsCount = 52)
        {
            var deck = GetDeck(deckName);
            if (deck != null) throw new Exception("Sorter already contains deck with this name");

            Decks.AddLast(new Deck(deckName, cardsCount));
        }

        public void DeleteDeck(string deckName)
        {
            var deck = GetDeck(deckName);
            if (deck == null) throw new Exception("Sorter does not contains deck with this name");

            Decks.Remove(deck);
        }

        public void ShuffleDeck(string deckName, ShuffleOption option = ShuffleOption.Simple)
        {
            var deck = GetDeck(deckName);
            if (deck == null) throw new Exception("Sorter does not contains deck with this name");

            deck.Shuffle(option);
        }

        public void SortDeck(string deckName)
        {
            var deck = GetDeck(deckName);
            if (deck == null) throw new Exception("Sorter does not contains deck with this name");

            deck.Sort();
        }

        public string[] GetDecksNames()
        {
            return Decks
                .Select(d => d.Name)
                .OrderBy(s => s)
                .ToArray();
        }

        public Deck? GetDeck(string deckName)
        {
            return Decks
                .FirstOrDefault(d => d.Name == deckName);
        }
    }
}
