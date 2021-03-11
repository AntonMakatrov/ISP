using System;
using System.Text;

namespace Lab_2
{
    class Task1
    {
        static void Main()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("---Task with DateTime objects---\n");
            Console.ForegroundColor = ConsoleColor.Gray;
            string currentTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string currentTime2 = DateTime.Now.ToString("HH:mm K");

            int[] numbers = new int[10];
            int[] numbers2 = new int[10];
            foreach (char symbol in currentTime)
            {
                switch (symbol)
                {
                    case '0':
                        {
                            numbers[0]++;
                            break;
                        }
                    case '1':
                        {
                            numbers[1]++;
                            break;
                        }
                    case '2':
                        {
                            numbers[2]++;
                            break;
                        }
                    case '3':
                        {
                            numbers[3]++;
                            break;
                        }
                    case '4':
                        {
                            numbers[4]++;
                            break;
                        }
                    case '5':
                        {
                            numbers[5]++;
                            break;
                        }
                    case '6':
                        {
                            numbers[6]++;
                            break;
                        }
                    case '7':
                        {
                            numbers[7]++;
                            break;
                        }
                    case '8':
                        {
                            numbers[8]++;
                            break;
                        }
                    case '9':
                        {
                            numbers[9]++;
                            break;
                        }
                }
            }

            foreach (char symbol in currentTime2)
            {
                switch (symbol)
                {
                    case '0':
                        {
                            numbers2[0]++;
                            break;
                        }
                    case '1':
                        {
                            numbers2[1]++;
                            break;
                        }
                    case '2':
                        {
                            numbers2[2]++;
                            break;
                        }
                    case '3':
                        {
                            numbers2[3]++;
                            break;
                        }
                    case '4':
                        {
                            numbers2[4]++;
                            break;
                        }
                    case '5':
                        {
                            numbers2[5]++;
                            break;
                        }
                    case '6':
                        {
                            numbers2[6]++;
                            break;
                        }
                    case '7':
                        {
                            numbers2[7]++;
                            break;
                        }
                    case '8':
                        {
                            numbers2[8]++;
                            break;
                        }
                    case '9':
                        {
                            numbers2[9]++;
                            break;
                        }
                }
            }
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"{currentTime}");

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Number of {i} in current date-time is: {numbers[i]}");
            }

            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine($"\n{currentTime2}");

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Number of {i} in current2 date-time is: {numbers2[i]}");
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n---End of task with DateTime objects---\n");
             
            Console.ReadKey();
        }
    }
}