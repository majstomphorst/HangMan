using System;
using System.Collections.Generic;
using System.Linq;

namespace HangMan
{
    public class HangManGame
    {
        private const short GUESSES_GAME_DEFAULT = 7;
        private Word WordList { get; set; }
        private List<char> AvailableLetters { get; set; }
        private string SecretWord  { get; set; }    
        private List<char> GuessLetters { get; set; }
        private short Guesses { get; set; } = GUESSES_GAME_DEFAULT;


        public HangManGame(Word wordList)
        {
            WordList = wordList;
            SecretWord = new string(WordList.GetRandomWord()).ToLower();
            GuessLetters = new List<char>();
            AvailableLetters = new List<char>(GenerateAvailableLetter());
        }

        public void ResetGame()
        {
            SecretWord = new string(WordList.GetRandomWord()).ToLower();
            GuessLetters = new List<char>();
            AvailableLetters = new List<char>(GenerateAvailableLetter());
            Guesses = GUESSES_GAME_DEFAULT;
            DisplayStatus();
        }

        private List<char> GenerateAvailableLetter()
        {
            var list = new List<char>();
            for (char letter = 'a'; letter <= 'z'; letter++)
            {
                list.Add(letter);
            }
            return list;
        }

        public void welcome()
        {
            Console.WriteLine();
            Console.WriteLine("Welcome the game start now you have {0} guesses to get the secretWord! \n good luck!", Guesses);
            Console.WriteLine("secret word {0}", SecretWord);
        }

        public void DisplayVicotry()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Vicotry!");
        }

        public void DisplayDefeaut()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("You lost! the word was: {0}", SecretWord);
        }

        public void DisplayStatus()
        {
            Console.WriteLine("Won: {0}", Won());
            Console.WriteLine("you have {0} guesses left", Guesses);

            writeList("Available letters to guess: ", AvailableLetters);
            writeList("Guess letters: ", GuessLetters);

            var i = SecretWord.Select(letter => GuessLetters.Contains(letter) ? letter : '_');
            Console.Write(string.Join(' ', i));

            Console.WriteLine();
        }

        private void writeList(string headText, List<char> list)
        {
            Console.Write(headText);
            Console.Write(string.Join(' ', list));
            Console.WriteLine();
        }

        public void GetGuess()
        {
            char letter;
            do
            {
                Console.WriteLine();
                Console.Write("place give me a char: ");
                letter = Console.ReadKey().KeyChar;

                if (letter == Convert.ToChar(":"))
                {
                    ResetGame();
                }

            } while (!CorrectInput(letter));

            Console.WriteLine();
            letter = char.ToLower(letter);

            AvailableLetters.Remove(letter);
            GuessLetters.Add(letter);
        }

        private bool CorrectInput(char letter)
        {
            if (char.IsLetter(letter) && !GuessLetters.Contains(letter))
            {
                return true;
            }
            return false;
        }


        public bool Complete()
        {
            if (Guesses <= 0 || Won())
            {
                return true;
            }
            return false;
        }

        public bool Won()
        {
            return SecretWord.All(letter => GuessLetters.Contains(letter));
        }

        public void CorrectGuess()
        {
            if (!SecretWord.Contains(GuessLetters.LastOrDefault()))
            {
                Guesses--;
            }
        }

    }
}
