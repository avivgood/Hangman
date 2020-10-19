using System;
using System.Collections.Generic;
using System.Text;
using HangmanAPI.WordsMatching;
using HangmanAPI.Wrappers;

namespace HangmanAPI
{
    class PlayThrough
    {
        public PlayerWrapperClass p { get; }
        public GameWrapperClass g { get; }
        public int CurrentTries { get; set; }
        private IWordTemplate WordTemplate { get; }

        public PlayThrough(GameWrapperClass currentGame, PlayerWrapperClass currentPlayer, IWordTemplate wordTemplate)
        {
            this.CurrentTries = 0;
            this.WordTemplate = wordTemplate;
            this.p = currentPlayer;
            this.g = currentGame;
        }
        public bool HasWon
        {
            get => WordTemplate.ToString() == g.word && CurrentTries <= g.MaxTries;
        }
        public int TriesLeft
        {
            get => g.MaxTries - CurrentTries;
        }
        public bool HasLost
        {
            get => CurrentTries == g.MaxTries;
        }
        public IList<char> Template
        {
            get => WordTemplate.CurrentTemplate;
        }
        public bool Guess(char letter)
        {
            if (CurrentTries >= g.MaxTries)
            {
            }
            bool guessResult = WordTemplate.Guess(letter);
            if (!guessResult)
                CurrentTries += 1;
            return guessResult;
        }
    }
}
