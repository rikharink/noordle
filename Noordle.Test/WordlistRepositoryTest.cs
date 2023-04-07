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
        var words = _repo.GetWordsOfLength(5).ToList();
        foreach (var word in words)
        {
            Assert.That(word, Has.Length.EqualTo(5));    
        }
        
        Assert.That(words, Does.Not.Contain("1000e"));
        Assert.That(words, Does.Not.Contain("27 MC"));
        Assert.That(words, Does.Not.Contain("3-tal"));
        Assert.That(words, Does.Not.Contain("aanw."));
        Assert.That(words, Does.Not.Contain("A-bom"));
    }
}