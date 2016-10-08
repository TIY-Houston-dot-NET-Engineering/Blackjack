using System;

namespace BlackJack {

    public enum Suit
    {
        Hearts,
        Spades,
        Diamonds,
        Clubs
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

        public override string ToString(){
            return $"{asSuit()} {asRank()}";
        }

        public string asSuit(){
            switch(suit) {
                case Suit.Hearts: return "♥";
                case Suit.Clubs: return "♣";
                case Suit.Diamonds: return "♦";
                case Suit.Spades: return "♤";
                default: return "___";
            }
        }

        public string asRank() {
            switch(rank){
                case Rank.Ace: return "A";
                case Rank.Deuce: return "2";
                case Rank.Three: return "3";
                case Rank.Four: return "4";
                case Rank.Five: return "5";
                case Rank.Six: return "6";
                case Rank.Seven: return "7";
                case Rank.Eight: return "8";
                case Rank.Nine: return "9";
                case Rank.Ten: return "10";
                case Rank.Jack: return "J";
                case Rank.Queen: return "Q";
                case Rank.King: return "K";
                default: return "__";
            }
        }

        public int asScore(){
            switch(rank){
                case Rank.Ace: return 11;
                case Rank.Deuce: return 2;
                case Rank.Three: return 3;
                case Rank.Four: return 4;
                case Rank.Five: return 5;
                case Rank.Six: return 6;
                case Rank.Seven: return 7;
                case Rank.Eight: return 8;
                case Rank.Nine: return 9;
                case Rank.Ten: return 10;
                case Rank.Jack: return 10;
                case Rank.Queen: return 10;
                case Rank.King: return 10;
                default: return 0;
            }
        }

        public Card(Suit s, Rank r){
            suit = s;
            rank = r;
        }
    }

    public class Deck {

        public Card[] cards;
        private int numDealt = 0;

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

            randomize(); // shuffle card array
        }

        //  swap two indices
        public static void swap(Card[] arr, int a, int b){
            var temp = arr[a];
            arr[a] = arr[b];
            arr[b] = temp;
        }

        public void randomize(){
            for(int i = 0; i < 52; i++){
                int r = new Random().Next(i, 51);
                swap(cards, i, r);
            }
        }

        public Card deal() => 
            (numDealt < cards.Length) ? cards[numDealt++] : null;
    }

    public class Hand {
        public Card[] cards = new Card[0];
        
        public int score(){
            int s = 0;
            foreach(Card c in cards){
                s += c.asScore();
            }
            return s;
        }

        public override string ToString(){
            string r = "";
            int i = 0;
            foreach(Card c in cards) {
                r = i++ == 0 ? $"{c}" : $"{r}, {c}";
            }
            return $"Player Hand: {r} - score: {score()}";
        }

        public void take(Card newCard) {
            var temp = new Card[cards.Length + 1];
            int i = 0;
            foreach(Card c in cards){
                temp[i++] = c;
            }
            temp[i] = newCard;
            cards = temp;
        }
    }

    public class DealerHand : Hand {
        public override string ToString(){
            string r = "";
            int i = 0;
            foreach(Card c in cards) {
                r = i++ == 0 ? $"{c}" : $"{r}, *";
            }
            return $"Dealer Hand: {r} - score: ???";
        }

        public string show(){
            string r = "";
            int i = 0;
            foreach(Card c in cards) {
                r = i++ == 0 ? $"{c}" : $"{r}, {c}";
            }
            return $"Dealer Hand: {r} - score: {score()}";
        }
    }
}