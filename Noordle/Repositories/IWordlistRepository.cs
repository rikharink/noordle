namespace Noordle.Services;

public interface IWordlistRepository
{
    public IList<string> GetWordsOfLength(int wordLength);
}