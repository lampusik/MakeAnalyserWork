using System;
using FunnyAnalyser.Library.Interfaces;
using FunnyAnalyser.Library.Models;

namespace FunnyAnalyser.Library.Providers
{
    public class FunnyAnalyserProvider : IFunnyAnalyserProvider
    {
        private Char[] _separators = new Char[] { ' ', ',', '.', ':', '\t' };

        public Word[] Process(string phrase)
        {
            var wordsCountResult = SplitPhrase(phrase);
            return wordsCountResult; 
        }

        private Word[] SplitPhrase(string phrase)
        {
            var wordsList = phrase.Split(_separators);
            var unickWordsCount = CountUnickWords(wordsList);

            wordsList = wordsList.SortByASCII();
            wordsList = wordsList.SortByLength();

            var wordsCountResult = new Word[unickWordsCount];

            int countResult = 0;
            
            for (int i = 0; i < wordsList.Length; i++)
            {
                if (!IsWordAdded(wordsCountResult, wordsList[i]))
                {
                    wordsCountResult[countResult] = CountWords(wordsList, wordsList[i]);
                    countResult++;
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
            int count = 0;
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

        private bool IsWordAdded(Word[] wordsResult, string item)
        {
            for (int i = 0; i < wordsResult.Length; i++)
            {
                if(wordsResult[i] == null)
                {
                    return false;
                }

                if (wordsResult[i].Item.Equals(item))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
