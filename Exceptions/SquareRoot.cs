using System;

namespace ExceptionSquareRoot
{
    class SquareRoot
    {
        static void Main(string[] args)
        {
            try
            {
                int n = int.Parse(Console.ReadLine());

                double result = Sqrt(n);

                Console.WriteLine($"Square root of {n} is = {result}");

            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.Error.WriteLine("Error: " + ex.Message);
                throw;
            }
            finally
            {
                Console.WriteLine("Good-bye");
            }
        }

        public static double Sqrt(double value)
        {
            if (value < 0)
            {
                throw new System.ArgumentOutOfRangeException(nameof(value), "Sqrt for negative numbers is undefined!");
            }
            return Math.Sqrt(value);
        }
    }
}
