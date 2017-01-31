using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _238FalloutHackingGame
{
    class Program
    {
        static void Main(string[] args)
        {
            bool wantsToPlay = true;

            while (wantsToPlay)
            {
                string response = "";
                HackingGame game = new HackingGame();
                List<string> words = game.SetWordsWithDifficulty();
                game.PlayGame(words);

                do
                {
                    Console.WriteLine("Do you want to play again? Y/N");
                    response = Console.ReadLine();
                    if (response.ToUpper() == "N")
                    {
                        wantsToPlay = false;
                        break;
                    }
                } while (response.ToUpper() != "Y");
            }
        }
    }
}

public class HackingGame
{
    public HackingGame()
    {

    }

    public List<string> SetWordsWithDifficulty()
    {
        List<string> gameWords = new List<string>();
        int difficulty = 0;

        do
        {
            Console.WriteLine("Input difficulty (1-5): ");
            int.TryParse(Console.ReadLine(), out difficulty);

            switch (difficulty)
            {
                case 1:
                    gameWords = GetGameWords(4, 6);
                    break;
                case 2:
                    gameWords = GetGameWords(6, 8);
                    break;
                case 3:
                    gameWords = GetGameWords(8, 11);
                    break;
                case 4:
                    gameWords = GetGameWords(10, 13);
                    break;
                case 5:
                    gameWords = GetGameWords(12, 15);
                    break;
                default:
                    difficulty = 0;
                    break;
            }
        } while (difficulty == 0);

        return gameWords;
    }

    private List<string> GetGameWords(int wordLength, int amountWords)
    {
        string[] words = File.ReadAllLines(@"C:\Users\Joostul\Source\Repos\DailyChallenges\239AGameOfThrees\238FalloutHackingGame\238FalloutHackingGame\txt\enable1.txt")
            .Select(s => s.ToUpperInvariant())
            .ToArray();

        return words.Where(x => x.Length == wordLength)
            .OrderBy(g => Guid.NewGuid())
            .Take(amountWords)
            .ToList();
    }

    internal void PlayGame(List<string> words)
    {
        foreach (var word in words)
        {
            Console.WriteLine(word);
        }

        words = words.OrderBy(a => Guid.NewGuid()).ToList();
        string correctWord = words[0];

        int guessesLeft = 4;
        bool hasWon = false;

        while (guessesLeft > 0 && hasWon == false)
        {
            Console.WriteLine("Now guess a word ({0} guesses left): "
                , guessesLeft);
            string guess = Console.ReadLine().ToUpper();
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
                    for (int i = 0; i < correctWord.Length; i++)
                    {
                        if (guess[i] == correctWord[i])
                        {
                            correctLetters += 1;
                        }
                    }

                    Console.WriteLine("{0} out of {1} characters were correct (and in the correct location), please guess again."
                        , correctLetters
                        , correctWord.Length);
                }
            }
            else
            {
                guessesLeft -= 1;
                Console.WriteLine("Your word is not in the list.");
            }
        }

        if (hasWon)
        {
            Console.WriteLine("You guessed correctly! Congratulations!");
        }
        else
        {
            Console.WriteLine("No guesses left, your word was {0}"
                , correctWord);
        }
    }
}