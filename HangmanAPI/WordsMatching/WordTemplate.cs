using System;
using System.Collections.Generic;
using System.Linq;

namespace HangmanAPI.WordsMatching
{
    public class WordTemplate : IWordTemplate
    {
        private ICollection<char> guessedChars;
        private string WordToGuess { get; }

        public IList<char> CurrentTemplate { get; }


        public WordTemplate(string wordToGuess)
        {
            WordToGuess = wordToGuess;
            CurrentTemplate = Enumerable.Repeat<Char>('\0', WordToGuess.Length).ToList();
            for(int i = 0; i < wordToGuess.Length; i++)
                if (wordToGuess[i] == ' ')
                    CurrentTemplate[i] = ' ';
            guessedChars = new HashSet<char>();
        }
        public WordTemplate(string wordToGuess, IEnumerable<char> guessed) : this(wordToGuess)
        {
            foreach (var c in guessed)
                Guess(c);
        }
        public bool Guess(char letterToGuess)
        {
            if (!char.IsLower(letterToGuess) && !char.IsUpper(letterToGuess))
            {
                throw new ArgumentException("character provided is not in english alphabet");
            }
            letterToGuess = Char.ToLower(letterToGuess);
            if (guessedChars.Contains(letterToGuess)){}
                guessedChars.Add(letterToGuess);
            bool found = false;
            
            for (int i = 0; i < CurrentTemplate.Count; i++)
            {
                if (WordToGuess[i] == letterToGuess)
                {
                    found = true;
                    CurrentTemplate[i] = letterToGuess;
                }
            }

            return found;
        }

        public override string ToString()
        {
            string temp = "";
            foreach (var c in CurrentTemplate)
            {
                temp += c == '\0' ? '■' : c;
            }

            return temp;
        }
    }
}
