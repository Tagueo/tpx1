using System;
using System.IO;
using System.Text;
using System.Threading;

namespace CardBattle
{
   class Program
    {
        class Player1
        {
            public static string name = "Player 1";
            public static int score = 7;
        }
        
        class Player2
        {
            public static string name = "Player 2";
            public static int score = 7;
        }
        
        public static void Main(string[] args)
        {
            Console.CursorVisible = false;
            
            Player1.name = Gui.Prompt("Player 1 name :");
            Player2.name = Gui.Prompt("Player 2 name :");
            
            InitInterface();
            
            var resStr = $"Press any key to start the round";
            Gui.WriteAt(resStr, Console.WindowWidth / 2 - resStr.Length / 2, 12);
            Console.ReadKey();

            bool playing = true;
            while (playing)
            {
                PlayRound(1);

                Console.ReadKey();

                if (Player1.score <= 0 || Player2.score <= 0)
                {
                    playing = false;
                }
            }

            string name = Player1.score <= 0 ? Player2.name : Player1.name;
            resStr = $"{name} won the game!";
            Gui.WriteAt(resStr, Console.WindowWidth / 2 - resStr.Length / 2, 14);
        }

        public static void InitInterface()
        {
            Gui.WriteAt(Player1.name, 1, 1);
            Gui.WriteAt(Player1.score.ToString(), 1, 2);
            
            Gui.WriteAt(Player2.name, Console.WindowWidth - Player2.name.Length - 1, 1);
            string play2score = Player2.score.ToString();
            Gui.WriteAt(play2score, Console.WindowWidth - play2score.Length - 1, 2);
        }

        public static void PlayRound(int iteration)
        {
            Console.Clear();
            InitInterface();

            (int val1, string card1) = Cards.Get();
            (int val2, string card2) = Cards.Get();
            
            var str = $"Suspens ...";
            Gui.WriteAt(str, Console.WindowWidth / 2 - str.Length / 2, 12);
            Thread.Sleep(500);
            Gui.WriteAt(card1, 4, 6);
            Thread.Sleep(500);
            Gui.WriteAt(card2, Console.WindowWidth - 11, 6);
            Thread.Sleep(500);

            if (val1 > val2)
            {
                var resStr = $"{Player1.name} won the round, press any key to continue ...";
                Gui.WriteAt(resStr, Console.WindowWidth / 2 - resStr.Length / 2, 12);
                Player1.score += iteration;
                Player2.score -= iteration;
                InitInterface();
            }
            else if (val1 < val2)
            {
                var resStr = $"{Player2.name} won the round, press any key to continue ...";
                Gui.WriteAt(resStr, Console.WindowWidth / 2 - resStr.Length / 2, 12);
                Player1.score -= iteration;
                Player2.score += iteration; 
                InitInterface();
            }
            else
            {
                Gui.WriteAt("BATAILLE ! Press any key to draw again ...", Console.WindowWidth / 2 - 21, 12);
                Console.Read();
                PlayRound(++iteration);
            }
        }
    }
}