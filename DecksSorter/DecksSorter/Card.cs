using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecksSorter
{
    public class Card : IComparable<Card>
    {
        public readonly Suit Suit;
        public readonly Rank Rank;

        public Card(Suit suit, Rank rank)
        {
            this.Suit = suit;
            this.Rank = rank;
        }

        public int CompareTo(Card? obj)
        {
            var other = obj as Card;
            return (int)other.Rank == (int)this.Rank ?
                (int)other.Suit > (int)this.Suit ? -1 : 1
                : (int)other.Rank > (int)this.Rank ? -1 : 1;
        }

        public override bool Equals(object? obj)
        {
            var other = obj as Card;
            if (other == null) return false;
            if (other.Suit == Suit && other.Rank == Rank) return true;
            return false;
        }
    }
}
