using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _238FalloutHackingGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int difficulty;
            int guessesLeft = 4;
            string guess;
                
            int.TryParse(Console.ReadLine(), out difficulty);

            foreach(string word in _words)
            {
                Console.WriteLine(word);
            }
            Console.WriteLine("Now guess a word ({0} guesses left): ", guessesLeft);
            guess = Console.ReadLine().ToUpper();

            while(guessesLeft < 5)
            {
                if (_words.Contains(guess))
                {
                    if (guess == _words[0])
                    {
                        Console.WriteLine("You guessed correctly!");
                    }
                    else
                    {
                        guessesLeft -= 1;
                        Console.WriteLine("You guessed incorrectly, please guess again.");
                        // Check how many letters are correct.
                    }
                }
                else
                {
                    Console.WriteLine("Your word is not in the list.");
                }
            }
            Console.ReadKey();
        }

        static List<string> _words = new List<string>(new string[] { "TESTING", "INTERST", "UPLOADS", "CLOTHES", "WORRIED" });
    }
}
