using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ProjectEuler.HelperClasses;

namespace ProjectEuler.Problems
{
    class Problem54
    {
        public static int categoryMatch = 0;
        public void Method()
        {
            Console.WriteLine("determine how many hands Player 1 wins in a game of poker");
            // use the file poker.txt to see which random hands are dealt and count Player 1's wins

            string filename = "54poker.txt";
            string[] file = File.ReadAllLines(filename);

            int p1WinCount = file.Sum(bothHands => DidPlayerOneWin(bothHands));

            Console.WriteLine($"P1 won {p1WinCount} games out of {file.Length}");
            Console.WriteLine("haven't finished tie breaker, result may be off");
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

            if (category1 > category2)
                return 1;
            if (category2 > category1)
                return 0;

            // category1 must equal category 2 at this point

            switch (category1)
            {
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
                    // if they are equal, get the remaining hand and compare the high cards for both 
                    var d2 = p1Cards.Where(c => c.value != getValueCard(dv1));
                    var e2 = p2Cards.Where(c => c.value != ev1);
                    var dv2 = getCardValue(d2.Max(c => c.value));
                    var ev2 = getCardValue(e2.Max(c => c.value));
                    return dv2 > ev2 ? 1 : 0;
                case (int) HandCategory.TwoPair:
                    var f = p1Cards.Select(c => c.value).GroupBy(v => v).Where(v => v.Count() == 2).Select(v => v.Key);
                    var g = p2Cards.Select(c => c.value).GroupBy(v => v).Where(v => v.Count() == 2).Select(v => v.Key);
                    var fv1 = getCardValue(f.Max());
                    var gv1 = getCardValue(g.Max());
                    if (fv1 != gv1)
                        return fv1 > gv1 ? 1 : 0;
                    var fv2 = getCardValue(f.FirstOrDefault(fv => fv != fv1));
                    var gv2 = getCardValue(g.FirstOrDefault(gv => gv != gv1));
                    
                    return 1;
                case (int) HandCategory.ThreeOfAKind:
                    return 1;
                case (int) HandCategory.Straight:
                    return 1;
                case (int) HandCategory.Flush:
                    return 1;
                case (int) HandCategory.FullHouse:
                    return 1;
                case (int) HandCategory.FourOfAKind:
                    return 1;
                case (int) HandCategory.StraightFlush:
                    return 1;
                case (int) HandCategory.RoyalFlush:
                    return 1;

            }

            categoryMatch++;
            return 0;
        }

        private static int getCategory(Card[] hand)
        {
            if (IsRoyalFlush(hand))
                return (int) HandCategory.RoyalFlush;
            if (IsStraightFlush(hand))
                return (int) HandCategory.StraightFlush;
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
            var suits = hand.Select(c => c.suit).Distinct();
            var values = hand.Select(c => c.value).Distinct();
            return suits.Count() <= 3 && values.Count() <= 4;
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
            Dictionary<char, int> dict = new Dictionary<char, int>();
            foreach (char value in hand.Select(c => c.value))
            {
                if (dict.ContainsKey(value))
                    dict[value]++;
                else
                    dict[value] = 1;
            }

            return dict.Keys.Count == 3 && dict.Keys.Any(k => dict[k] == 3);
        }

        private static bool IsTwoPair(Card[] hand) => hand.Select(c => c.value).Distinct().Count() == 3;

        private static bool IsOnePair(Card[] hand) => hand.Select(c => c.value).Distinct().Count() == 4;

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

