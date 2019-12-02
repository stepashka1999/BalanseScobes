using System;
using System.Collections.Generic;

namespace BalanseScobes
{
    class Program
    {
        private static Char[] OpenScobArray = { '{', '[', '(' };
        private static Char[] CloseScobArray = { '}', ']', ')' };

        //Решил, что допускается ввод текста в скобках, т.к. в задании это условие отсутсвует
        static void Main(string[] args)
        {
            Console.WriteLine("\nВведите скобочную структуру: ");
            string Stroke = Console.ReadLine().ToString();

            if (isBalansed(Stroke)) Console.WriteLine("Строка сбалансирована.");
            else Console.WriteLine("Строка не сбалансирована  или введено выражение не содержащее скобок.");

            Console.WriteLine("Если хотите ввести строку еще раз нажмите Y:");
            
            if (Console.ReadKey().Key == ConsoleKey.Y) Main(null);
        }

        private static bool isBalansed(string s)
        {
            bool isOpen = false;
            var openScobes = new List<int>();

            foreach(char symbol in s)
            {
                for(int i = 0; i < 3; i++)
                {
                    if (symbol == OpenScobArray[i])
                    { 
                        openScobes.Add(i);
                        isOpen = true;
                    } 
              
                    if(symbol == CloseScobArray[i])
                    {
                        if (openScobes.Count == 0) return false;
                        else if (symbol == CloseScobArray[ openScobes[openScobes.Count - 1] ]) openScobes.RemoveAt(openScobes.Count - 1);
                        else if(symbol != CloseScobArray[ openScobes[openScobes.Count - 1] ]) return false;
                    }
                }
            }
            if (openScobes.Count > 0) return false;
            
            return isOpen;
        }
    }
}
