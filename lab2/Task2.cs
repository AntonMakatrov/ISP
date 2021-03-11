using System;
using System.Text;

namespace Lab_2
{
    class Task2
    {
        static void Main()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n---Start of task with StringBuilder objects---\n");
            Console.ForegroundColor = ConsoleColor.Gray;

            Console.Write("Input the string: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            string input = Console.ReadLine() + " ";
            Console.ForegroundColor = ConsoleColor.Gray;

            StringBuilder reversedString = new StringBuilder();
            StringBuilder currentWord = new StringBuilder();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] != ' ')
                {
                    currentWord.Append(input[i]);
                }
                else
                {
                    currentWord.Append(' ');
                    reversedString.Insert(0, currentWord);
                    currentWord.Clear();
                }
            }

            reversedString.Remove(reversedString.Length - 1, 1);

            Console.WriteLine("\nThe string with reversed words is:");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"{reversedString.ToString()}");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n---End of task with StringBuilder objects---\n");
            Console.ForegroundColor = ConsoleColor.Gray;
        
            Console.ReadKey();
        }
    }
}