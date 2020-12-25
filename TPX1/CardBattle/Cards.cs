using System;

namespace CardBattle
{
    public class Cards
    {
        private static string[] symbols = new[] {"♣","♠","♥","♦"};

        private static string[] figures = new[] {"2","3","4","5","6","7","8","9","10","J","Q","K","A"};

        private static string Body(string figure, string symbol)
        {
            string res = "";
            
            switch (figure)
            {
                case "2":
                    res = $"│ {figure}  {symbol}    │\n" +
                          $"│         │\n" +
                          $"│         │\n" +
                          $"│         │\n" +
                          $"│         │\n" +
                          $"│         │\n" +
                          $"│    {symbol}  {figure} │\n";
                    break;
                case "3":
                    res = $"│ {figure}  {symbol}    │\n" +
                          $"│         │\n" +
                          $"│         │\n" +
                          $"│    {symbol}    │\n" +
                          $"│         │\n" +
                          $"│         │\n" +
                          $"│    {symbol}  {figure} │\n";
                    break;
                case "4":
                    res = $"│ {figure} {symbol} {symbol}   │\n" +
                          $"│         │\n" +
                          $"│         │\n" +
                          $"│         │\n" +
                          $"│         │\n" +
                          $"│         │\n" +
                          $"│   {symbol} {symbol} {figure} │\n";
                    break;
                case "5":
                    res = $"│ {figure} {symbol} {symbol}   │\n" +
                          $"│         │\n" +
                          $"│         │\n" +
                          $"│    {symbol}    │\n" +
                          $"│         │\n" +
                          $"│         │\n" +
                          $"│   {symbol} {symbol} {figure} │\n";
                    break;
                case "6":
                    res = $"│ {figure} {symbol} {symbol}   │\n" +
                          $"│         │\n" +
                          $"│         │\n" +
                          $"│   {symbol} {symbol}   │\n" +
                          $"│         │\n" +
                          $"│         │\n" +
                          $"│   {symbol} {symbol} {figure} │\n";
                    break;
                case "7":
                    res = $"│ {figure} {symbol} {symbol}   │\n" +
                          $"│    {symbol}    │\n" +
                          $"│   {symbol} {symbol}   │\n" +
                          $"│         │\n" +
                          $"│         │\n" +
                          $"│         │\n" +
                          $"│   {symbol} {symbol} {figure} │\n";
                    break;
                case "8":
                    res = $"│ {figure} {symbol} {symbol}   │\n" +
                          $"│         │\n" +
                          $"│    {symbol}    │\n" +
                          $"│   {symbol} {symbol}   │\n" +
                          $"│    {symbol}    │\n" +
                          $"│         │\n" +
                          $"│   {symbol} {symbol} {figure} │\n";
                    break;
                case "9":
                    res = $"│ {figure} {symbol} {symbol}   │\n" +
                          $"│         │\n" +
                          $"│   {symbol} {symbol}   │\n" +
                          $"│    {symbol}    │\n" +
                          $"│   {symbol} {symbol}   │\n" +
                          $"│         │\n" +
                          $"│   {symbol} {symbol} {figure} │\n";
                    break;
                case "10":
                    res = $"│ {figure}{symbol} {symbol}   │\n" +
                          $"│    {symbol}    │\n" +
                          $"│   {symbol} {symbol}   │\n" +
                          $"│         │\n" +
                          $"│   {symbol} {symbol}   │\n" +
                          $"│    {symbol}    │\n" +
                          $"│   {symbol} {symbol}{figure} │\n";
                    break;
                case "J":
                    res = $"│ {figure}       │\n" +
                          $"│     WW  │\n" +
                          $"│     {{)  │\n" +
                          $"│  ({symbol})%   │\n" +
                          $"│   {symbol}%%   │\n" +
                          $"│   %%%[  │\n" +
                          $"│       {figure} │\n";
                    break;
                case "Q":
                    res = $"│ {figure}       │\n" +
                          $"│     ww  │\n" +
                          $"│     {{(  │\n" +
                          $"│  ({symbol})%%  │\n" +
                          $"│   {symbol}%%%  │\n" +
                          $"│   %%%O  │\n" +
                          $"│       {figure} │\n";
                    break;
                case "K":
                    res = $"│ {figure}       │\n" +
                          $"│     WW  │\n" +
                          $"│     {{)  │\n" +
                          $"│  ({symbol})%%  │\n" +
                          $"│   {symbol}%%%  │\n" +
                          $"│   %%%>  │\n" +
                          $"│       {figure} │\n";
                    break;
                case "A":
                    res = $"│ {figure}       │\n" +
                          $"│         │\n" +
                          $"│         │\n" +
                          $"│    {symbol}    │\n" +
                          $"│         │\n" +
                          $"│         │\n" +
                          $"│       {figure} │\n";
                    break;
                default:
                    res = $"│         │\n" +
                          $"│         │\n" +
                          $"│         │\n" +
                          $"│         │\n" +
                          $"│         │\n" +
                          $"│         │\n" +
                          $"│         │\n";
                    break;
            }

            return res;
        }

        public static (int, string) Get()
        {
            int cardFig = new Random().Next(12);
            int symbol = new Random().Next(3);

            string frame = 
                "┌─────────┐\n" +
                Body(figures[cardFig], symbols[symbol]) +
                "└─────────┘";

            return (cardFig, frame);
        }
    }
}