using System;
using TextAnalyser.Library.Interfaces;
using TextAnalyser.Library.Models;

namespace TextAnalyser.Library.Providers
{
    public class TextAnalyserProvider : ITextAnalyserProvider
    {
        private Char[] _separators = new Char[] { ' ', ',', '.', ':', '\t' };

        public Word[] Process(string phrase)
        {
            var wordsCountResult = SplitPhrase(phrase);
                      
            return wordsCountResult.SortWordLength(); 
        }

        private Word[] SplitPhrase(string phrase)
        {
            var wordsList = phrase.Split(_separators);
            wordsList = wordsList.SortAIIS();
            var unickWordsCount = CountUnickWords(wordsList);

            var wordsCountResult = new Word[unickWordsCount];

            int countResult = 0;
            string oldWord = wordsList[0];
            wordsCountResult[countResult] = CountWords(wordsList, wordsList[0]);

            for (int i = 1; i < wordsList.Length; i++)
            {
                if (oldWord != wordsList[i])
                {
                    oldWord = wordsList[i];
                    countResult++;
                    wordsCountResult[countResult] = CountWords(wordsList, wordsList[i]);
                }
            }

            return wordsCountResult;
        }
        
        private Word CountWords(string[] wordsList, string item)
        {
            int count = 0;

            for (int i = 0; i < wordsList.Length; i++)
            {
                if (wordsList[i].Equals(item))
                {
                    count++;
                }
            }

            return new Word
            {
                Item = item,
                Count = count
            };
        }

        private int CountUnickWords(string[] wordsList)
        {
            int count = 1;
            string oldWord = wordsList[0];

            for (int i = 1; i < wordsList.Length; i++)
            {
                if (!wordsList[i].Equals(oldWord))
                {
                    oldWord = wordsList[i];
                    count++;
                }
            }
            return count;
        }
    }
}
