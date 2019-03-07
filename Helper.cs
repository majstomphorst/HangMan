using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;


namespace HangMan
{
    public class Word
    {
        private List<string> WordsList = new List<string>();

        public Word()
        {
            ReadWordsFile();
        }

        public string GetRandomWord()
        {
            Random rnd = new Random();
            int r = rnd.Next(WordsList.Count());
            return WordsList[r];
        }

        private void ReadWordsFile()
        {
            var filePath = @"assets/words.txt";
            foreach (string word in File.ReadAllLines(filePath))
            {
                if (word.Any(letter => !char.IsLetter(letter)))
                {
                    continue;
                }
                WordsList.Add(word);
            }
        }

    }
}