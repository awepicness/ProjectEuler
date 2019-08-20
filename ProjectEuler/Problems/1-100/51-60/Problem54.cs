using System;
using System.Collections.Generic;
using System.IO;
using ProjectEuler.HelperClasses;

namespace ProjectEuler.Problems
{
    class Problem54
    {
        public void Method2()
        {
            Console.WriteLine("determine how many hands Player 1 wins in a game of poker");
            // use the file poker.txt to see which random hands are dealt and count Player 1's wins

            string filename = "54poker.txt";
            string[] file = File.ReadAllLines(filename);

            int p1WinCount = 0;

            foreach (string bothHands in file)
            {
                int match = DetermineWinner(bothHands);
                //switch (match)
                //{
                //    case 1:
                //        p1WinCount++;
                //}

            }

            Console.WriteLine($"P1 won {p1WinCount} games out of {file.Length}");
        }

        // 1: p1 wins
        // 0: p1 loses (p2 wins)
        // -1: tie / error
        private static int DetermineWinner(string bothHands)
        {
            const int cardsPerHand = 5;

            string p1Hand = bothHands.Substring(0, 14);
            string p2Hand = bothHands.Substring(15);

            string[] p1CardStrings = p1Hand.Split(' ');
            string[] p2CardStrings = p2Hand.Split(' ');

            if (p1CardStrings.Length != cardsPerHand || p2CardStrings.Length != cardsPerHand)
                return -1;

            Card[] p1Cards = new Card[p1CardStrings.Length];
            Card[] p2Cards = new Card[p2CardStrings.Length];

            for (int i = 0; i < p1CardStrings.Length; i++)
            {
                p1Cards[i] = new Card { value = p1CardStrings[i][0], suit = p1CardStrings[i][1] };
                p2Cards[i] = new Card { value = p2CardStrings[i][0], suit = p2CardStrings[i][1] };
            }

            int[] p1Score = GetHandScore(p1Cards);
            int[] p2Score = GetHandScore(p2Cards);

            if (p1Score[0] == p2Score[0]) // categories match
            {
                if (p1Score[1] == p2Score[1]) // cards match too
                    return -1; // uhh
                if (p1Score[1] > p2Score[1]) // p1 wins
                    return 1;
                return 0; // p2 wins
            }

            if (p1Score[0] > p2Score[0]) // p1 wins
                return 1;
            return 0; // p2 wins
        }

        private static int[] GetHandScore(Card[] hand)
        {
            // result[0] = category, result[1] = sum of values of cards
            int[] result = new int[2];

            // determine how many matching values there are
            HashSet<char> values = new HashSet<char>();
            HashSet<char> suits = new HashSet<char>();
            foreach (Card card in hand)
            {
                values.Add(card.value);
                suits.Add(card.suit);
            }

            switch (values.Count)
            {
                // 4 of a kind, full house, 
                case 2:


                // two pair, three of a kind, 
                case 3:
                    break;

                // one pair
                case 4:
                    break;

                // high card, straight, flush, straight flush, royal flush
                case 5:

                    break;
            }

            return result;
        }
    }

    public enum HandCategory
    {
        HighCard = 0, // all 5 cards are different values
        OnePair = 1, // 1 distinct value pair, 3 remaining cards are different values
        TwoPair = 2, // 2 distinct value pairs, 5th card is different value
        ThreeOfAKind = 3, // 3 cards of same value, 2 remaining values cannot be a pair
        Straight = 4, // 5 cards in order (not same suit)
        Flush = 5, // all cards are the same suit
        FullHouse = 6, // 3 of a kind and a pair (k k k 5 5). ties are broken 1st by 3 of a kind, then pair. kkk22 beats qqqaa, which beats qqqjj
        FourOfAKind = 7, // ex: 4 4 4 4 2
        StraightFlush = 8, // 5 cards in order of the same suit (5s 6s 7s 8s 9s) but doesn't wrap (not qs ks as 1s 2s)
        RoyalFlush = 9 // best straight flush (10 j q k a)
        // ignore 5 of a kind, no wild cards
    }
}

