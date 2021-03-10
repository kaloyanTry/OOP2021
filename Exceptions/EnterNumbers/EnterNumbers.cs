using System;

namespace EnterNumbers
{
    public class EnterNumbers
    {
        static void Main(string[] args)
        {
            try
            {
                ReadNumbers(1, 10);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void ReadNumbers(int start, int end)
        {
            int previusNumber = 0;
            for (int i = 0; i < 10; i++)
            {
                int number = int.Parse(Console.ReadLine());
                if (i == 0)
                {
                    previusNumber = number;
                }

                if (number < previusNumber || number < start || number > end)
                {
                    throw new ArgumentOutOfRangeException("Number not in range");
                }
            }
        }
    }
}
