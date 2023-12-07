using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    /// <summary>
    /// Подсчитать, сколько раз каждое слово встречается в за­данном тексте. 
    /// Результат записать в коллекцию Dictio­nary<TKey, TValue>. 
    /// Текст использовать из "приложения 1". 
    /// </summary>
    class Program
    {
        static void Main()
        {
            string text = @"Вот дом, Который построил Джек. А это пшеница, Которая в темном чулане хранится
                        В доме, Который построил Джек. А это веселая птица-синица, Которая часто ворует
                        пшеницу, Которая в темном чулане хранится В доме, Который построил Джек.";

            var wordStatistics = CountWordOccurrences(text);

            DisplayStatistics(wordStatistics);
        }

        static Dictionary<string, int> CountWordOccurrences(string text)
        {
            var words = text.Split(new[] { ' ', '.', ',', '-', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            var wordCount = new Dictionary<string, int>();

            foreach (var word in words)
            {
                var normalizedWord = word.ToLower();

                if (wordCount.ContainsKey(normalizedWord))
                    wordCount[normalizedWord]++;
                else
                    wordCount[normalizedWord] = 1;
            }

            return wordCount;
        }

        static void DisplayStatistics(Dictionary<string, int> wordStatistics)
        {
            Console.WriteLine("Word\t\tCount");
            Console.WriteLine("----------------------");

            foreach (var pair in wordStatistics.OrderBy(x => x.Key))
                Console.WriteLine($"{pair.Key}\t\t{pair.Value}");
        }
    }
}
