using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _239AGameOfThrees
{
    class Program
    {
        static void Main(string[] args)
        {
            int Number;
            int.TryParse(Console.ReadLine(), out Number);

            // While the number is not 1
            while (Number != 1)
            {
                // If the number is divisable by 3
                if(Number % 3 != 0)
                {
                    // Is not divisable by 3, should check if adding or subtracting one is better

                    // If subtracting one makes it divisable by 3
                    if ((Number - 1) % 3 == 0)
                    {
                        Console.WriteLine(Number + " - 1");
                        Number = (Number - 1) / 3;
                    }
                    // If adding one makes it divisable by 3
                    else if ((Number + 1) % 3 == 0)
                    {
                        Console.WriteLine(Number + " + 1");
                        Number = (Number + 1) / 3;
                    }
                } else
                {
                    // Then devide it by 3
                    Console.WriteLine(Number);
                    Number = Number / 3;
                }
            }

            // Puzzle is solved: 1 is left after deviding by three
            Console.WriteLine(Number);

            Console.ReadLine();
        }
    }
}
