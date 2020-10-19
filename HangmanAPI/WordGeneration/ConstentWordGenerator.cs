using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HangmanAPI.Enums;

namespace HangmanAPI.WordGeneration
{
    public class ConstentWordGenerator  : IWordGenerator
    {
        private IDictionary<WordTopic, List<string>> wordsByTopic = new Dictionary<WordTopic, List<string>>()
        {
            {WordTopic.Animals, new List<string>() {"fox", "cow", "goat", "bear", "cat"}},
            {WordTopic.Movies, new List<string>() {"starwars", "ghostbusters", "tenet", "antebellum", "mulan", "dune", "euphoria", "fargo", "mignonnes", "outlander"}},
            {WordTopic.Vehicle, new List<string>(){"car", "ship", "bike"}}
        };

        private IList<string> ChosenCollection;
        public ConstentWordGenerator(WordTopic topic)
        {
            ChosenCollection = wordsByTopic[topic];
        }
        public Task<string> GetWordAsync()
        {
            Random rnd = new Random();
            return Task.FromResult(ChosenCollection[rnd.Next(ChosenCollection.Count())]);
        }

        public Task<IEnumerable<string>> GetDistinctWordsAsync(int amount)
        {
            return Task.FromResult(ChosenCollection.Take(amount));
        }
    }
}
