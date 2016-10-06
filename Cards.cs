using System;

namespace BlackJack {
    public enum Suit
    {
        Hearts,
        Clubs,
        Diamonds,
        Spades
    }

    public enum Rank
    {
        Ace,
        Deuce,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King
    }

    public class Card {
        public Suit suit;
        public Rank rank;

        public Card(Suit s, Rank r){
            suit = s;
            rank = r;
        }
    }

    public class Deck {
        public Card[] cards;
        public Deck(){
            cards = new Card[52];
            int i = 0; // 1
            foreach (Rank r in Enum.GetValues(typeof(Rank)))
            {
                int j = 0;
                foreach (Suit s in Enum.GetValues(typeof(Suit)))
                {
                    cards[i*4 + j] = new Card(s, r);
                    j++;
                }
                i++;
            }
        }
        public Card[] getRandomized(){
            return new Card[0];
        }
    }
}