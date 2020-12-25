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

            int left = (Console.BufferWidth / 2) - (question.Length / 2) < 0 ? 0 : (Console.BufferWidth / 2) - (question.Length / 2);
            int top = (Console.BufferHeight / 2);
            
            Console.Clear();
            
            // Prints the question and wait for an answer at the center of the screen
            WriteAt(question, left,  top - 2);
            Console.SetCursorPosition(left, top);
            Console.CursorVisible = true;
            answer = Console.ReadLine();
            Console.CursorVisible = false;
            
            Console.Clear();
            
            return answer;
        }
    }
}