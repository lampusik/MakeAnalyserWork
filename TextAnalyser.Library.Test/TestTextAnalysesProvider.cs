using Microsoft.VisualStudio.TestTools.UnitTesting;
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
            var phrase = "The test to be test one time";
            var expected = new [] {
                new Word { Item = "be", Count = 1},
                new Word { Item = "test", Count = 2},
                new Word { Item = "to", Count = 1},
                new Word { Item = "be", Count = 1},
                new Word { Item = "one", Count = 1},
                new Word { Item = "time", Count = 1}
            };

            // Act
            var results = textAnalyserProvider.Process(phrase);

            // Assert
            Assert.AreEqual(results.Length, expected.Length);
            Assert.AreEqual(results[0].Item, expected[0].Item);
            Assert.AreEqual(results[0].Count, expected[0].Count);
        }
    }
}
