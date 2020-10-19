using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace HangmanAPI.WordGeneration
{
    public class RandomWordGenerator : IWordGenerator
    {
        private readonly HttpClient client;

        private const string WordGenerator =
            "https://random-word-api.herokuapp.com/word?number={0}";
        public RandomWordGenerator()
        {
            client = new HttpClient();

        }
        public async Task<string> GetWordAsync()
        {
            using (HttpResponseMessage response = await client.GetAsync(string.Format(WordGenerator, 1.ToString())))
            {
                if (response.IsSuccessStatusCode)
                {
                    string jsonString = await response.Content.ReadAsStringAsync();
                    return JsonSerializer.Deserialize<string[]>(jsonString)[0];
                }

                throw new HttpRequestException("Http request failed");
            }
        }

        public async Task<IEnumerable<string>> GetDistinctWordsAsync(int amount)
        {
            using (HttpResponseMessage response = await client.GetAsync(string.Format(WordGenerator, amount.ToString())))
            {
                if (response.IsSuccessStatusCode)
                {
                    string jsonString = await response.Content.ReadAsStringAsync();
                    return JsonSerializer.Deserialize<IEnumerable<string>>(jsonString);
                }

                throw new HttpRequestException("Http request failed");
            }
        }
    }
}
