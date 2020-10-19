using System.Collections.Generic;
using System.Threading.Tasks;

namespace HangmanAPI.WordGeneration
{
    public interface IWordGenerator
    {
        Task<string> GetWordAsync();
        Task<IEnumerable<string>> GetDistinctWordsAsync(int amount);
    }
}