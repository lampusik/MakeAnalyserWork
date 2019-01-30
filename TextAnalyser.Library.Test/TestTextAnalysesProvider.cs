using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using TextAnalyser.Library.Models;
using TextAnalyser.Library.Providers;

namespace TextAnalyser.Library.Test
{
    [TestClass]
    public class TestTextAnalysesProvider
    {
        [TestMethod]
        public void TestProcess()
        {
            // Arrange
            var textAnalyserProvider = new TextAnalyserProvider();           
            var phrase = "The quick brown fox jumped over the lazy brown dog’s back";

            var expected = getProperValuewWithLINQ(phrase);

            // Act
            var results = textAnalyserProvider.Process(phrase);

            // Assert
            Assert.AreEqual(results.Length, expected.Length);
            Assert.AreEqual(results[0].Item, expected[0].Item);
            Assert.AreEqual(results[0].Count, expected[0].Count);
            Assert.AreEqual(results[1].Item, expected[1].Item);
            Assert.AreEqual(results[1].Count, expected[1].Count);
            Assert.AreEqual(results[2].Item, expected[2].Item);
            Assert.AreEqual(results[2].Count, expected[2].Count);
            Assert.AreEqual(results[3].Item, expected[3].Item);
            Assert.AreEqual(results[3].Count, expected[3].Count);
            Assert.AreEqual(results[4].Item, expected[4].Item);
            Assert.AreEqual(results[4].Count, expected[4].Count);
            Assert.AreEqual(results[5].Item, expected[5].Item);
            Assert.AreEqual(results[5].Count, expected[5].Count);
            Assert.AreEqual(results[6].Item, expected[6].Item);
            Assert.AreEqual(results[6].Count, expected[6].Count);
            Assert.AreEqual(results[7].Item, expected[7].Item);
            Assert.AreEqual(results[7].Count, expected[7].Count);
            Assert.AreEqual(results[8].Item, expected[8].Item);
            Assert.AreEqual(results[8].Count, expected[8].Count);
            Assert.AreEqual(results[9].Item, expected[9].Item);
            Assert.AreEqual(results[9].Count, expected[9].Count);
        }

        private Word[] getProperValuewWithLINQ( string phrase) {
            var wordsResult = new List<Word>();
            var wordsList = phrase.Split(new Char[] { ' ', ',', '.', ':', '\t' });

            Array.Sort(wordsList, StringComparer.Ordinal);
            var words = wordsList.ToList();

            foreach (var word in words)
            {
                if (!wordsResult.Any() || !wordsResult.Exists(x => x.Item == word))
                {
                    wordsResult.Add(new Word
                    {
                        Item = word,
                        Count = words.Count(x => x == word)
                    });
                }
            }
            return wordsResult
                 .OrderBy(x => x.Item.Length)
                 .ToArray();
        } 
    }
}
