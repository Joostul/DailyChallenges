using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _238FalloutHackingGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int difficulty = 0;
            int amountWords = 0;
            int wordLength = 0;
            int guessesLeft = 4;
            string guess, correctWord, tempWord;
            bool hasWon = false;
            List<string> words = new List<string>();

            do
            {
                Console.WriteLine("Input difficulty (1-5): ");
                int.TryParse(Console.ReadLine(), out difficulty);
                
                switch (difficulty)
                {
                    case 1:
                        amountWords = 6;
                        wordLength = 5;
                        break;
                    case 2:
                        amountWords = 8;
                        wordLength = 7;
                        break;
                    case 3:
                        amountWords = 10;
                        wordLength = 9;
                        break;
                    case 4:
                        amountWords = 12;
                        wordLength = 12;
                        break;
                    case 5:
                        amountWords = 15;
                        wordLength = 15;
                        break;
                    default:
                        difficulty = 0;
                        break;
                }
            } while (difficulty == 0);
            Console.WriteLine("Loading, please wait...");


            WordImporter wi = new WordImporter();
            var importedWords = wi.importWords();

            // Choose word to be guessed
            do
            {
                Random r = new Random();
                int randomWord = r.Next(importedWords.Length);
                correctWord = importedWords[randomWord].ToUpper();
                if (correctWord.Length == wordLength)
                {
                    words.Add(correctWord);
                }
            }
            while (correctWord.Length != wordLength);

            // Choose the rest of the words
            while (words.Count < amountWords)
            {
                Random r = new Random();
                int randomWord = r.Next(importedWords.Length);
                tempWord = importedWords[randomWord].ToUpper();

                if(tempWord.Length == wordLength && !words.Contains(tempWord))
                {
                    words.Add(tempWord);
                }
            }

            // Put the words in random order and write them out
            words = words.OrderBy(a => Guid.NewGuid()).ToList();
            foreach(string word in words)
            {
                Console.WriteLine(word);
            }

            while (guessesLeft > 0 && hasWon == false)
            {
                Console.WriteLine("Now guess a word ({0} guesses left): ", guessesLeft);
                guess = Console.ReadLine().ToUpper();
                if (words.Contains(guess))
                {
                    if (guess == correctWord)
                    {
                        hasWon = true;
                    }
                    else
                    {
                        guessesLeft -= 1;
                        int correctLetters = 0;

                        // Check how many letters are correct.
                        for (int i = 0; i < wordLength; i++)
                        {
                            if(guess[i] == correctWord[i])
                            {
                                correctLetters += 1;
                            } 
                        }

                        Console.WriteLine("{0} out of {1} characters were correct, please guess again.", correctLetters, wordLength);
                    }
                }
                else
                {
                    guessesLeft -= 1;
                    Console.WriteLine("Your word is not in the list.");
                }
            }

            if(hasWon)
            {
                Console.WriteLine("You guessed correctly! Congratulations!");
            } else
            {
                Console.WriteLine("No guesses left, your word was {0}", correctWord);
            }

            Console.ReadKey();
        }
    }

    public class WordImporter
    {
        static List<string> _words = new List<string>(new string[] { "TESTING", "INTERST", "UPLOADS", "CLOTHES", "WORRIED" });

        public string[] importWords()
        {
            var importedWords = File.ReadAllLines(@"C:\Users\Joostul\Source\Repos\DailyChallenges\239AGameOfThrees\238FalloutHackingGame\238FalloutHackingGame\txt\enable1.txt");

            return importedWords;
        }
    }
}
