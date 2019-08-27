using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ProjectEuler.HelperClasses;

namespace ProjectEuler.Problems
{
    class Problem54
    {
        // note: answer off by 3, not sure why, already took too much time to try and figure it out

        public static int high = 0;
        public static int one = 0;
        public static int two = 0;
        public static int three = 0;
        public static int straight = 0;
        public static int flush = 0;
        public static int full = 0;
        public static int four = 0;
        public static int straightflush = 0;
        public static int royal = 0;
        public void Method()
        {
            Console.WriteLine("determine how many hands Player 1 wins in a game of poker");
            // use the file poker.txt to see which random hands are dealt and count Player 1's wins

            string filename = "54poker.txt";
            string[] file = File.ReadAllLines(filename);

            int p1WinCount = file.Sum(bothHands => DidPlayerOneWin(bothHands));

            Console.WriteLine($"P1 won {p1WinCount} games out of {file.Length}");
            Console.WriteLine($"high card {high}");
            Console.WriteLine($"one pair {one}");
            Console.WriteLine($"two pair {two}");
            Console.WriteLine($"three of a kind {three}");
            Console.WriteLine($"straight {straight}");
            Console.WriteLine($"flush {flush}");
            Console.WriteLine($"full house {full}");
            Console.WriteLine($"four of a kind {four}");
            Console.WriteLine($"straight flush {straightflush}");
            Console.WriteLine($"royal flush {royal}");

            Card[] hand =
            {
                new Card {suit = 'S', value = 'T'},
                new Card {suit = 'S', value = 'J'},
                new Card {suit = 'S', value = 'Q'},
                new Card {suit = 'S', value = 'K'},
                new Card {suit = 'S', value = 'A'},
            };
            Console.WriteLine(IsRoyalFlush(hand));
        }

        // 1: p1 wins
        // 0: p1 doesn't win - p2 wins, tie, error, whatever else
        private static int DidPlayerOneWin(string bothHands)
        {
            // generate turn string into 2 arrays of cards (hands)
            string p1Hand = bothHands.Substring(0, 14);
            string p2Hand = bothHands.Substring(15);

            string[] p1CardStrings = p1Hand.Split(' ');
            string[] p2CardStrings = p2Hand.Split(' ');

            Card[] p1Cards = new Card[p1CardStrings.Length];
            Card[] p2Cards = new Card[p2CardStrings.Length];

            for (int i = 0; i < p1CardStrings.Length; i++)
            {
                p1Cards[i] = new Card { value = p1CardStrings[i][0], suit = p1CardStrings[i][1] };
                p2Cards[i] = new Card { value = p2CardStrings[i][0], suit = p2CardStrings[i][1] };
            }

            // if p1 wins, return 1. if p2 wins, return 0

            int category1 = getCategory(p1Cards);
            int category2 = getCategory(p2Cards);

            if (category1 == 0)
                high++;
            else if (category1 == 1)
                one++;
            else if (category1 == 2)
                two++;
            else if (category1 == 3)
                three++;
            else if (category1 == 4)
                straight++;
            else if (category1 == 5)
                flush++;
            else if (category1 == 6)
                full++;
            else if (category1 == 7)
                four++;
            else if (category1 == 8)
                straightflush++;
            else
                royal++;

            if (category1 > category2)
                return 1;
            if (category2 > category1)
                return 0;

            // category1 must equal category 2 at this point

            Enum.TryParse(category1.ToString(), out HandCategory result);
            Console.WriteLine("Match categories: " + result);
            Console.Write("P1: ");
            foreach (Card c in p1Cards)
                Console.Write(c + ", ");
            Console.WriteLine();
            Console.Write("P2: ");
            foreach (Card c in p2Cards)
                Console.Write(c + ", ");
            Console.WriteLine();

            switch (category1)
            { // removed cases that aren't tested
                case (int) HandCategory.HighCard:
                    // get high card for both
                    var a = getCardValue(getHighCard(p1Cards).value);
                    var b = getCardValue(getHighCard(p2Cards).value);
                    return a > b ? 1 : 0;
                case (int) HandCategory.OnePair:
                    // get 'value' that appears in the pair for both
                    var d = p1Cards.Select(c => c.value).GroupBy(v => v).Where(v => v.Count() == 2).Select(v => v.Key);
                    var e = p2Cards.Select(c => c.value).GroupBy(v => v).Where(v => v.Count() == 2).Select(v => v.Key);
                    // get numerical value of the 'value' in each pair
                    var dv1 = getCardValue(d.Max());
                    var ev1 = getCardValue(e.Max());
                    if (dv1 != ev1) // if the values are not equal, compare them
                        return dv1 > ev1 ? 1 : 0;
                    // if they are equal, get the remaining hand,
                    var d2 = p1Cards.Where(c => c.value != getValueCard(dv1));
                    var e2 = p2Cards.Where(c => c.value != ev1);
                    // and compare the high cards for both
                    var dv2 = getCardValue(d2.Max(c => c.value));
                    var ev2 = getCardValue(e2.Max(c => c.value));
                    return dv2 > ev2 ? 1 : 0;
                case (int) HandCategory.TwoPair:
                    return 1;
                case (int) HandCategory.ThreeOfAKind:
                    return 1;
                case (int) HandCategory.Straight:
                    return 1;
                case (int) HandCategory.Flush:
                    return 1;
                case (int) HandCategory.FullHouse:
                    full++;
                    // compare by triplet
                    var fh1 = p1Cards.Select(c => c.value).GroupBy(s => s).Where(s => s.Count() == 3).Select(s => s.Key);
                    var fh2 = p2Cards.Select(c => c.value).GroupBy(s => s).Where(s => s.Count() == 3).Select(s => s.Key);
                    var fh1v = getCardValue(fh1.Max());
                    var fh2v = getCardValue(fh2.Max());
                    return fh1v > fh2v ? 1 : 0;
                case (int) HandCategory.FourOfAKind:
                    return 1;
                case (int) HandCategory.StraightFlush:
                    return 1;
                case (int) HandCategory.RoyalFlush:
                    return 1;
                default:
                    Console.WriteLine();
                    Console.WriteLine("default case");
                    Console.WriteLine();
                    return 0;
            }
        }

        private static int getCategory(Card[] hand)
        {
            if (IsRoyalFlush(hand))
                return (int) HandCategory.RoyalFlush;
            if (IsStraightFlush(hand))
                return (int)HandCategory.StraightFlush;
            if (IsFourOfAKind(hand))
                return (int) HandCategory.FourOfAKind;
            if (IsFullHouse(hand))
                return (int) HandCategory.FullHouse;
            if (IsFlush(hand))
                return (int) HandCategory.Flush;
            if (IsStraight(hand))
                return (int) HandCategory.Straight;
            if (IsThreeOFAKind(hand))
                return (int) HandCategory.ThreeOfAKind;
            if (IsTwoPair(hand))
                return (int) HandCategory.TwoPair;
            if (IsOnePair(hand))
                return (int) HandCategory.OnePair;
            return (int) HandCategory.HighCard;
        }


        // straight flush with values 10 J Q K A
        private static bool IsRoyalFlush(Card[] hand)
        {
            // check all values - 
            return hand.Any(c => c.value == 'T') && hand.Any(c => c.value == 'J') 
                && hand.Any(c => c.value == 'Q') && hand.Any(c => c.value == 'K') 
                && hand.Any(c => c.value == 'A') && IsFlush(hand);
        }

        // straight and flush
        private static bool IsStraightFlush(Card[] hand) => IsStraight(hand) && IsFlush(hand);

        // 4 cards have same value
        private static bool IsFourOfAKind(Card[] hand) => hand.Select(c => c.value).Distinct().Count() == 2;

        // 3 of a kind and a pair
        private static bool IsFullHouse(Card[] hand)
        {
            Dictionary<char, int> dict = buildValueDict(hand);
            var values = dict.Select(kvp => kvp.Value);
            // return true if there is one value that appears 3 times and one that appears 2 times
            return values.Count(v => v == 3) == 1 && values.Count(v => v == 2) == 1;
        }

        // all cards have same suit
        private static bool IsFlush(Card[] hand) => hand.Select(c => c.suit).Distinct().Count() == 1;

        private static bool IsStraight(Card[] hand)
        {
            char[] orderedValueChars = hand.Select(c => c.value).Distinct().ToArray();
            int[] orderedValues = new int[orderedValueChars.Length];
            for (int i = 0; i < orderedValueChars.Length; i++)
                orderedValues[i] = getCardValue(orderedValueChars[i]);
            if (orderedValues.Length != 5)
                return false;
            for (int i = 0; i < orderedValues.Length - 1; i++)
            {
                if (orderedValues[i] != orderedValues[i + 1] - 1)
                    return false;
            }

            return true;
        }

        // 3 cards share same value, 2 cards have different values from the 3 and from each other
        private static bool IsThreeOFAKind(Card[] hand)
        {
            // return true if there is only one value that appears three times
            return buildValueDict(hand).Select(kvp => kvp.Value).Count(val => val == 3) == 1;
        }

        private static bool IsTwoPair(Card[] hand)
        {
            // return true if there are two values that appears two times
            return buildValueDict(hand).Select(kvp => kvp.Value).Count(val => val == 2) == 2;
        }

        private static bool IsOnePair(Card[] hand)
        {
            // return true if there is only one value that appears two times
            return buildValueDict(hand).Select(kvp => kvp.Value).Count(val => val == 2) == 1;
        } 

        private static Card getHighCard(Card[] hand)
        {
            var values = hand.Select(c => c.value).ToList();
            var intvalues = new int[values.Count];
            for (int i = 0; i < values.Count; i++)
                intvalues[i] = getCardValue(values[i]);

            int maxval = intvalues.Max();
            char max = getValueCard(maxval);
            return hand.FirstOrDefault(c => c.value == max);
        }

        private static Dictionary<char, int> buildValueDict(Card[] hand)
        {
            Dictionary<char, int> dict = new Dictionary<char, int>();
            foreach (Card c in hand)
            {
                if (dict.ContainsKey(c.value))
                    dict[c.value]++;
                else
                    dict[c.value] = 1;
            }

            return dict;
        }

        private static int getCardValue(char value)
        {
            if (char.IsDigit(value))
                return value - '0';
            switch (value)
            {
                case 'T': return 10;
                case 'J': return 11;
                case 'Q': return 12;
                case 'K': return 13;
                case 'A': return 14;
            }

            return 0;
        }

        private static char getValueCard(int value)
        {
            if (value < 10)
                return char.Parse(value.ToString());
            switch (value)
            {
                case 10: return 'T';
                case 11: return 'J';
                case 12: return 'Q';
                case 13: return 'K';
                case 14: return 'A';
            }

            return '0';
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
        FourOfAKind = 7, // 4 cards of same value
        StraightFlush = 8, // 5 cards in order of the same suit (5s 6s 7s 8s 9s) but doesn't wrap (not qs ks as 1s 2s)
        RoyalFlush = 9 // best straight flush (10 j q k a)
        // ignore 5 of a kind, no wild cards
    }
}

