﻿using System;
using System.Threading;
using CardBattle;

namespace Polynomial
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            
            bool running = true;
            int tab = 0;
            int tabNumber = 2;
            
            float[] polynomial = new float[] { };
            float x = 0;
            
            while (running)
            {
                DrawScreen(tab, polynomial, x);

                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.LeftArrow:
                        tab = tab - 1 < 0 ? 1 : tab - 1;
                        break;
                    case ConsoleKey.RightArrow:
                        tab = (tab + 1) % tabNumber;
                        break;
                    case ConsoleKey.F1:
                    case ConsoleKey.D1:
                        tab = 0;
                        break;
                    case ConsoleKey.F2:
                    case ConsoleKey.D2:
                        tab = 1;
                        break;
                    case ConsoleKey.Enter:
                        switch (tab)
                        {
                            case 0:
                                float coeff = (float) Convert.ToDouble(Gui.Prompt("Enter a valid coefficient (decimal number):"));
                                DrawScreen(tab, polynomial, x);
                                int exp =  Convert.ToInt32(Gui.Prompt("Enter a valid exponent (integer):"));
                                
                                polynomial = Poly.AddCoefficient(polynomial, coeff, exp);
                                break;
                            case 1:
                                x = (float) Convert.ToDouble(Gui.Prompt("Enter x (decimal number):"));
                                break;
                        }
                        break;
                    case ConsoleKey.F4:
                        string path = Gui.Prompt("Load: Enter the file's path:");
                        string fileContent = IO.ReadFile(path);
                        polynomial = Format.StringToFloatArr(fileContent);
                        break;
                    case ConsoleKey.F5:
                        path = Gui.Prompt("Save: Enter the file's path:");
                        IO.WriteFile(path, Format.FloatArrToString(polynomial));
                        break;
                    case ConsoleKey.Escape:
                        running = false;
                        break;
                }
            }
        }
        
        public static void DrawScreen(int i, float[] floats, float x)
        {
            Console.Clear();
            
            switch (i)
            {
                case 0:
                    EditTab(floats);
                    break;
                case 1:
                    ComputeTab(floats, x);
                    break;
                default:
                    i = 0;
                    EditTab(floats);
                    break;
            }

            Gui.Tabs(new[] {"Edit", "Compute"}, i);
        }

        public static void EditTab(float[] polynomial)
        {
            int left = 1;
            int top = 2;
            
            Gui.WriteAt("┌─────────────────┬─────┐", left, top);
            Gui.WriteAt("│   Coefficient   │ Exp │", left, ++top);
            Gui.WriteAt("├─────────────────┼─────┤", left, ++top);
            
            for (int i = 0; i < polynomial.Length; i++)
            {
                string coeff = polynomial[i].ToString(Thread.CurrentThread.CurrentCulture);
                string exp = i.ToString();

                if (coeff != "0")
                {
                    int coeffLen = coeff.Length;
                    if (coeffLen > 15)
                    {
                        coeff = coeff.Remove(15);
                        coeffLen = coeff.Length;
                    }
                
                    int coeffSpaces = 15 - coeffLen;
                    for (int j = 0; j < coeffSpaces; j++)
                        coeff += " ";
                
                    int expSpaces = 3 - exp.Length;
                    for (int j = 0; j < expSpaces; j++)
                        exp += " ";

                    Gui.WriteAt($"│ {coeff} │ {exp} │", left, ++top);
                }
            }
            
            Gui.WriteAt("└─────────────────┴─────┘", left, ++top);

            top += 2;
            
            Gui.WriteAt("Press Enter to add a line", left, top);
        }
        
        static void ComputeTab(float[] polynomial, float x = 0)
        {
            string polyFormated = "";
            int n = 0;

            for (int i = polynomial.Length - 1; i >= 0; i--)
            {
                string coeff = polynomial[i].ToString(Thread.CurrentThread.CurrentCulture);
                string exp = i.ToString();

                if (coeff != "0")
                {
                    if (n == 0)
                        if (i == 0)
                            polyFormated += $"{coeff}";
                        else if (i == 1)
                            polyFormated += $"{coeff}x";
                        else
                            polyFormated += $"{coeff}x^{exp}";
                    else if (polynomial[i] < 0)
                        if (i == 0)
                            polyFormated += $" {coeff}";
                        else if (i == 1)
                            polyFormated += $" {coeff}x";
                        else
                            polyFormated += $" {coeff}x^{exp}";
                    else
                        if (i == 0)
                            polyFormated += $" + {coeff}";
                        else if (i == 1)
                            polyFormated += $" + {coeff}x";
                        else
                            polyFormated += $" + {coeff}x^{exp}";

                    n++;
                }
            }

            Gui.WriteAt("Polynomial :", 1, 2);
            Gui.WriteAt(polyFormated, 1, 4);
            Gui.WriteAt("Press ENTER to select x and compute", 1, 10);
            
            Gui.WriteAt($"Result with x = {x}: {Poly.ComputePolynomial(x, polynomial)}", 1, 12);
        }
    }
}