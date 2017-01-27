using System;

namespace _239AGameOfThrees
{
    class Program
    {
        static void Main(string[] args)
        {
            int number;
            int.TryParse(Console.ReadLine(), out number);

            // While the number is not 1
            while (number != 1)
            {
                // If the number is divisable by 3
                int n = number % 3;
                if(n != 0)
                {
                    // If the result is 2 then add one, if it is 1 then remove one
                    n = (n == 1 ? -1 : 1);
                }

                // Execute the action
                Console.WriteLine(number + (n == 0 ? "": " " + n));
                number += n;
                number = number / 3;
            }
            Console.WriteLine(number);

            Console.ReadLine();
        }
    }
}
