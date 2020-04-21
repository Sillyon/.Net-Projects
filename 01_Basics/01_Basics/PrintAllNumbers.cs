using System;

namespace _01_Basics
{
    /// <summary>
    /// Prints numbers from 1 to 100
    /// </summary>
    public class PrintAllNumbers
    {
        public static void PrintInAscendingOrder()
        {
            SumOfNumbers.Sum_A(5);
            Console.WriteLine("Numbers from 1 to 100, in ascending order:");
            for (int i = 1; i <= 100; i++)
            {
                Console.Write(i + "\t"); //beautifying
            }
        }

        public static void PrintInDescendingOrder()
        {
            Console.WriteLine("Numbers from 1 to 100, in descending order:");
            for (int i = 100; i >= 1; i--)
            {
                Console.Write(i + "\t"); //beautifying
            }
        }
    }
}
