namespace Noordle.Services;

public interface IWordlistRepository
{
    public IAsyncEnumerable<string> GetWordsOfLength(int wordLength);
}