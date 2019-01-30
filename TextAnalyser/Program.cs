using System;
using TextAnalyser.Library.Providers;

namespace TextAnalyser
{
   public class TextAnalyser
    {
        static void Main(string[] args)
        {
            var textAnalyserProvider = new TextAnalyserProvider();
            Console.WriteLine("Please enter your sentence to analyze");
            string phrase = Console.ReadLine();

            if (string.IsNullOrEmpty(phrase))
            {
                Console.WriteLine("Sorry your string is empty");
            }
            else
            {
                var results = textAnalyserProvider.Process(phrase);
                for (int i = 0; i < results.Length; i++)
                {
                    Console.WriteLine(results[i].Count.ToString() + " " + results[i].Item+ "\n");
                }
            }
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
}
