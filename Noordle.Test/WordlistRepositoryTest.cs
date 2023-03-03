using Noordle.Services;
using Noordle.Services.Implementations;

namespace Noordle.Test;

public class WordlistRepositoryTest
{
    private IWordlistRepository _repo = null!;
    
    [SetUp]
    public void Setup()
    {
        _repo = new WordlistRepository();
    }

    [Test]
    public void WordlistRepository_GetWordsOfLength_ReturnsCorrectLengthWords()
    {
        foreach (var word in _repo.GetWordsOfLength(5))
        {
            Assert.That(word, Has.Length.EqualTo(5));    
        }
    }
}