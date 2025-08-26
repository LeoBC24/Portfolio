using System;
using System.Collections.Generic;

namespace pelipoker
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Tervetuloa pelaamaan Blackjackia!");

            // Luodaan korttipakka ja pelaaja
            Deck deck = new Deck();
            Console.WriteLine("Anna nimesi kiitos");
            string name = Console.ReadLine();
            Player player = new Player(name, deck);

            player.money = 100;  // Pelaajalla on aluksi 100 rahaa

            while (player.gamerunning)
            {
                // Kysytään pelaajalta panos
                bool betOK = false;
                while (betOK == false)
{
    Console.WriteLine("Paljonko haluat laittaa panokseksi? 1-10");
    string input = Console.ReadLine();  // Get the user input

    // Try to parse the input into an integer
    if (int.TryParse(input, out player.bet))
    {
        if (player.bet <= player.money && player.bet >= 1 && player.bet <= 10)
        {
            betOK = true;  // If the bet is valid, exit the loop
        }
        else
        {
            Console.WriteLine("Virheellinen panos, yritä uudestaan.");
        }
    }
    else
    {
        Console.WriteLine("Virheellinen syöte, syötä vain numero.");
    }
}


                player.money -= player.bet;  // Subtract the bet from the player's money before the round

                // Jaetaan kortit
                deck.Deal(player, 2);
                deck.Deal(player, 2, "dealer");

                // Näytetään pelaajan ja jakajan kädet
                player.ShowHand();
                deck.ShowDealerHand();

                // Pelaaja voi valita toimintoja
                while (player.GetHandValue() < 21)
                {
                    Console.WriteLine("Haluatko vetää kortin (H) vai jäädä (J)?");
                    string action = Console.ReadLine().ToUpper();

                    if (action == "H")
                    {
                        deck.Deal(player, 1);
                        player.ShowHand();
                    }
                    else if (action == "J")
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Virheellinen valinta. Valitse 'H' tai 'J'.");
                    }
                }

                // Jakaja ottaa kortteja jos käden arvo on alle 17
                deck.PlayDealerHand();

                // Tarkistetaan voittaja
                player.CheckResults(deck);

                // If the player runs out of money, end the game
                if (player.money <= 0)
                {
                    Console.WriteLine("Olet menettänyt kaiken rahasi. Peli päättyy.");
                    player.gamerunning = false;
                    break;
                }

                // Kysy pelaajalta, haluaako hän jatkaa
                Console.WriteLine("Haluatko jatkaa peliä? (K/E)");
                string continueGame = Console.ReadLine().ToUpper();
                if (continueGame == "E")
                {
                    player.gamerunning = false;
                }
                else
                {
                    // Reset and shuffle deck after each round
                    deck.ResetDeck(); // Reset the deck
                    deck.ShuffleDeck(); // Shuffle the deck
                    player.ResetHand(); // Reset player's hand
                }
            }

            Console.WriteLine("Kiitos kun pelasit Blackjackia!");
        }
    }

    class Deck
    {
        private List<int> deckCards;
        public List<int> takenCards = new List<int>();
        public List<int> dealerHand = new List<int>();

        public Deck()
        {
            ResetDeck();  // Initialize the deck and shuffle it
        }

        public void ShuffleDeck()
        {
            Random random = new Random();
            for (int i = 0; i < deckCards.Count; i++)
            {
                int swapIndex = random.Next(0, deckCards.Count);
                int temp = deckCards[i];
                deckCards[i] = deckCards[swapIndex];
                deckCards[swapIndex] = temp;
            }
        }

        public void Deal(Player player, int amount, string recipient = "player")
        {
            if (deckCards.Count == 0)
            {
                Console.WriteLine("Deck is empty. Cannot deal any more cards.");
                return;
            }

            for (int i = 0; i < amount; i++)
            {
                if (deckCards.Count == 0)  // Check again in case cards are depleted during the loop
                {
                    Console.WriteLine("Deck is empty. Cannot deal any more cards.");
                    break;
                }

                int card = deckCards[0];
                deckCards.RemoveAt(0); // Remove the dealt card from the deck

                if (recipient == "player")
                {
                    player.hand.Add(card);
                }
                else if (recipient == "dealer")
                {
                    dealerHand.Add(card);
                }
            }
        }

        public void ShowDealerHand()
        {
            if (dealerHand.Count > 0)
            {
                Console.WriteLine("Jakajan käden ensimmäinen kortti: " + ConvertCardToText(dealerHand[0]));
            }
            else
            {
                Console.WriteLine("Jakajan käsi ei ole vielä jaettu.");
            }
        }

        public void PlayDealerHand()
        {
            while (GetHandValue(dealerHand) < 17)
            {
                Deal(null, 1, "dealer");
                Console.WriteLine("Jakaja ottaa kortin.");
            }
            Console.WriteLine("Jakajan käsi: ");
            foreach (var card in dealerHand)
            {
                Console.WriteLine(ConvertCardToText(card));
            }
        }

        public int GetHandValue(List<int> hand)
        {
            int value = 0;
            int aceCount = 0;

            foreach (int card in hand)
            {
                int cardValue = GetCardValue(card);
                if (cardValue == 1)
                {
                    aceCount++;
                }
                value += cardValue;
            }

            // Lisätään ässä arvo 11, jos se ei mene yli 21
            while (aceCount > 0 && value + 10 <= 21)
            {
                value += 10;
                aceCount--;
            }

            return value;
        }

        public int GetCardValue(int card)
        {
            int number = card % 13;
            if (number == 0) return 11;  // Ässä
            if (number >= 10) return 10; // Jätkä, kuningatar, kuningas
            return number + 1;
        }

        public string ConvertCardToText(int card)
        {
            string[] suits = { "Hertta", "Ruutu", "Risti", "Pata" };
            string[] values = { "Ässä", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jätkä", "Kuningatar", "Kuningas" };

            int suit = card / 13;
            int value = card % 13;

            return $"{values[value]} {suits[suit]}";
        }

        // Reset the deck with 52 cards and shuffle
        public void ResetDeck()
        {
            deckCards = new List<int>(); // Clear any previous deck content
            takenCards.Clear();
            dealerHand.Clear();

            // Refill deck with 52 cards
            for (int i = 0; i < 52; i++)
            {
                deckCards.Add(i);  // 52 korttia
            }

            ShuffleDeck();  // Shuffle the deck after resetting
        }
    }

    class Player
    {
        public string name;
        public List<int> hand = new List<int>();
        public int money;
        public int bet;
        public bool gamerunning = true;

        private Deck deck;

        public Player(string name, Deck deck)
        {
            this.name = name;
            this.deck = deck;
        }

        public void ShowHand()
        {
            Console.WriteLine($"{name}'s käsi:");
            foreach (int card in hand)
            {
                Console.WriteLine(deck.ConvertCardToText(card));
            }
            Console.WriteLine("Käden arvo: " + GetHandValue());
        }

        public int GetHandValue()
        {
            return deck.GetHandValue(hand);
        }

        public void CheckResults(Deck deck)
        {
            int playerValue = GetHandValue();
            int dealerValue = deck.GetHandValue(deck.dealerHand);

            Console.WriteLine($"Pelaajan käden arvo: {playerValue}");
            Console.WriteLine($"Jakajan käden arvo: {dealerValue}");

            if (playerValue > 21)
            {
                Console.WriteLine("Hävisit! Menetit panoksesi.");
            }
            else if (dealerValue > 21 || playerValue > dealerValue)
            {
                Console.WriteLine("Voitit! Voitit panoksesi.");
                money += bet * 2;  // Double the bet when the player wins
            }
            else if (playerValue < dealerValue)
            {
                Console.WriteLine("Hävisit! Menetit panoksesi.");
            }
            else
            {
                Console.WriteLine("Tasapeli!");
                money += bet;  // In case of a tie, the bet is returned to the player
            }

            // Display the player's current money
            Console.WriteLine($"Sinulla on nyt {money} rahaa.");
        }

        public void ResetHand()
        {
            hand.Clear();  // Only reset player's hand, not the dealer's
        }
    }
}
