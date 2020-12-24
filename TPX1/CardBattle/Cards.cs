using System;

namespace CardBattle
{
    public class Cards
    {
        private static string[] symbols = new[] {"CLB", "SPD", "HRT", "DIA"};

        private static string[] figures = new[] {"TWO", "TRH", "FOR", "FIV", "SIX", "SEV", "EIG", "NIN", "TEN", "JOC", "QUN", "KIN", "ACE"};

        public static (int, string) Get()
        {
            int cardFig = new Random().Next(12);
            int symbol = new Random().Next(3);
            
            string frame =
                 "+-----+\n" +
                $"| {figures[cardFig]} |\n" +
                $"| {symbols[symbol]} |\n" +
                 "+-----+";

            return (cardFig, frame);
        }
    }
}