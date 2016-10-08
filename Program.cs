using System;

namespace BlackJack
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Deck myDeck = new Deck();
            // Hand player = new Hand();
            // player.take(myDeck.deal());
            // Console.WriteLine(player);
            NewGame();
        }

        public static void NewGame(){
            Deck randomized = new Deck();
            Hand player = new Hand();
            DealerHand dealer = new DealerHand();

            Action<bool> print = (showDealer) => {
                Console.WriteLine(player);
                Console.WriteLine(showDealer ? dealer.show() : dealer.ToString());
            };

            Console.WriteLine("=======");

            // two initial deals
            player.take(randomized.deal());
            player.take(randomized.deal());
            dealer.take(randomized.deal());
            dealer.take(randomized.deal());

            while(dealer.score() < 16){
                dealer.take(randomized.deal());
            }

            if(player.score() < 21){
                print(false);

                // while "hit me"
                while(player.score() < 21 && prompt()){
                    player.take(randomized.deal());

                    print(false);

                    // game ends if user hits 21 or over 21
                    if(player.score() >= 21){
                        break;
                    }
                }
            }

            int a = player.score();
            int b = dealer.score();

            print(true);
            
            if(b <= 21  && (a > 21 || a < b)) {
                Console.WriteLine("\n\n -------- Dealer wins! -------- \n\n");
            } else if(b > 21 && a > 21 || a == b){
                Console.WriteLine("\n\n -------- Draw. -------- \n\n");
            } else {
                Console.WriteLine("\n\n -------- You win! -------- \n\n");
            }

            // play again?
            Console.WriteLine("++++++Play again? (y/N)++++++");
            if(Console.ReadKey().KeyChar.ToString().ToUpper() == "Y")
                NewGame();
        }

        public static bool prompt(){
            Console.WriteLine("\n\nHit me? (y/N)\n\n");
            string result = Console.ReadKey().KeyChar.ToString().ToUpper();
            Console.WriteLine("\n\n\n\n\n ");
            return result == "Y";
        } 
    }
}
