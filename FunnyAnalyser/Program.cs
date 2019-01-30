using System;
using FunnyAnalyser.Library.Providers;

namespace FunnyAnalyser
{
   public class FunnyAnalyser
    {
        static void Main(string[] args)
        {
            var FunnyAnalyserProvider = new FunnyAnalyserProvider();
            Console.WriteLine("Please enter your sentence to analyze");
            string phrase = Console.ReadLine();

            if (string.IsNullOrEmpty(phrase))
            {
                Console.WriteLine("Sorry your string is empty");
            }
            else
            {
                var results = FunnyAnalyserProvider.Process(phrase);
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
