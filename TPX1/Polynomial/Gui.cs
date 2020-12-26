using System;
using System.IO;
using System.Text;

namespace CardBattle
{
    public class Gui
    {
        // Make the buffer the size of the window to disallow scrolling and make the gui responsive
        private static void Normalize()
        {
            Console.CursorVisible = false;
            Console.BufferHeight = Console.WindowHeight;
            Console.BufferWidth = Console.WindowWidth;
        }

        public static void Tabs(string[] tabs, int selected)
        {
            int previous = 0;

            for (int i = 0; i < tabs.Length; i++)
            {
                var tab = tabs[i];

                if (i == selected)
                {
                    Console.ResetColor();
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    Console.ForegroundColor = ConsoleColor.White;
                }
                
                WriteAt($" {tab} ", 0 + previous, 0);
                
                previous += tab.Length + 2;
            }

            for (int i = previous; i < Console.BufferWidth; i++)
            {
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                WriteAt($" ", i, 0);
            }
            
            Console.ResetColor();
            WriteAt("Select Tab: F1, F2 or ← → | Load: F4 | Save: F5 | Quit: ESC", 0, Console.BufferHeight - 1);
        }
        
        public static void WriteAt(string str, int left, int top)
        {
            Normalize();

            var strs = str.Split("\n");

            for (int i = 0; i < strs.Length; i++)
            {
                var el = strs[i];
                
                Console.SetCursorPosition(left, top + i);
                Console.Write(el);
            }
        }

        public static string Prompt(string question)
        {
            Normalize();
            
            string answer = "";

            int left = (Console.BufferWidth / 2) - (question.Length / 2) < 2 ? 2 : (Console.BufferWidth / 2) - (question.Length / 2);
            int top = (Console.BufferHeight / 2);
            
            // Prints the box
            string hSide = "";
            for (int i = 0; i < question.Length + 2; i++)
                hSide += "═";
            string vSide = "";
            for (int i = 0; i <= 4; i++)
                vSide += "║\n";
            WriteAt($"╔{hSide}╗", left - 2, top - 4);
            WriteAt($"╚{hSide}╝", left - 2, top + 2);
            WriteAt(vSide, left - 2, top - 3);
            WriteAt(vSide, left + question.Length + 1, top - 3);

            // Prints the question and wait for an answer at the center of the screen
            WriteAt(question, left,  top - 2);
            Console.SetCursorPosition(left, top);
            Console.CursorVisible = true;
            answer = Console.ReadLine();
            Console.CursorVisible = false;

            return answer;
        }
    }
}