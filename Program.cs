using System;
using System.Collections.Generic;
using System.Linq;

namespace HangMan
{
    class Program
    {
        static void Main(string[] args)
        {
            var wordList = new Word();
            var game = new HangManGame(wordList);

            Console.Clear();
            game.welcome();
            System.Threading.Thread.Sleep(5000);

            while(!game.Complete()) {
                Console.Clear();
                game.DisplayStatus();
                game.GetGuess();
                game.CorrectGuess();
            }

            if(game.Won()) {
                game.DisplayVicotry();
            } else {
                game.DisplayDefeaut();
            }
        
        }
    }
}
