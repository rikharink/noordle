namespace Noordle.Services;

public interface IWordlistRepository
{
    public IEnumerable<string> GetWordsOfLength(int wordLength);
}