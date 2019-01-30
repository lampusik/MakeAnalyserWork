using FunnyAnalyser.Library.Models;

namespace FunnyAnalyser.Library.Interfaces
{
    public interface IFunnyAnalyserProvider
    {
        Word[] Process(string phrase);
    }
}
