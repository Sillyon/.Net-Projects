using System;
using static _01_Basics.PrintAllNumbers;

/// <author>Fatih Çomak</author>
/// <date>12.04.2020</date>
/// <time>19:16 (GMT+3)</time>

namespace _01_Basics
{
    /// <summary>
    /// Basic Console Application starts to run with this class.
    /// </summary>
    static class Program
    {
        static void Main(string[] args)
        {
            //Welcome screen
            Console.WriteLine("Welcome to Basic Console Application!");
            ScreenRefresh();

            PrintInAscendingOrder();
            ScreenRefresh();

            PrintInDescendingOrder();
            ScreenRefresh();

            PrintCalculate();
            ScreenRefresh();
        }

        // Prints calculated sum of numbers from 1 to n.
        private static void PrintCalculate()
        {
            Console.WriteLine("Calculate the sum of numbers from 1 to n!");
            // Need to define default n for use that in while loop.
            int n = 0;
            // while-loop for a valid positive number input.
            while (n <= 0)
            {
                Console.Write("\nEnter a valid positive number: ");
                try
                {
                    // An exception throws if input will be non number(character etc.)
                    n = int.Parse(Console.ReadLine());
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Error: " + e.Message);
                }
                // Note: Overflow does not need to be taken into account.
            }

            // Prints calculated sums by results of methods.
            Console.WriteLine("\nImplementation using a for-loop: " + SumOfNumbers.Sum_A(n));
            Console.WriteLine("Implementation using a while-loop: " + SumOfNumbers.Sum_B(n));
            Console.WriteLine("Implementation using LINQ: " + SumOfNumbers.Sum_C(n));
            Console.WriteLine("Implementation that runs in constant time O(1): " + SumOfNumbers.Sum_D(n));
        }

        // Screen wait and clean with any key enter.
        private static void ScreenRefresh()
        {
            Console.WriteLine("\nPress any key to continue..");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
