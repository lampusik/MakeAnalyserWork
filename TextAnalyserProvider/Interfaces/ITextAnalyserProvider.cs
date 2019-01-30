using TextAnalyser.Library.Models;

namespace TextAnalyser.Library.Interfaces
{
    public interface ITextAnalyserProvider
    {
        Word[] Process(string phrase);
    }
}
