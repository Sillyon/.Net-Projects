using System.Linq;

namespace _01_Basics
{
    /// <summary>
    /// Calculates sum of numbers from 1 to n.
    /// </summary>
    public class SumOfNumbers
    {
        /// for all methods in this class:
        /// <param name="n">The last number of calculation.</param>
        /// <returns>A number with the sum calculated.</returns>

        // Using a for-loop
        public static int Sum_A(int n)
        {
            /* local variable definition */
            int sum = 0;
            for (int i = 1; i <= n; i++)
            {
                sum += i;
            }
            return sum;
        }

        // Using a while-loop
        public static int Sum_B(int n)
        {
            /* local variable definition */
            int sum = 0;
            int i = 1;
            while (i <= n)
            {
                sum += i++;
            }
            return sum;
        }

        // Using LINQ
        public static int Sum_C(int n)
        {
            return Enumerable.Range(1, n).Sum();
        }

        // Using mathematical formula
        public static int Sum_D(int n)
        {
            return n * (n + 1) / 2;
        }
    }
}
