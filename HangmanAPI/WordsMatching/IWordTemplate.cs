using System.Collections.Generic;

namespace HangmanAPI.WordsMatching
{
    public interface IWordTemplate
    {
        bool Guess(char letter);

        IList<char> CurrentTemplate
        {
            get;
        }
    }
}
