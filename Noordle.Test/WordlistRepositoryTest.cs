using System.Text.RegularExpressions;
using Noordle.Services.Implementations;

namespace Noordle.Test;

public partial class WordlistRepositoryTest
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public async Task WordlistRepository_Get_ReturnsCorrectLengthWords()
    {
        var repo = new WordlistRepository();
        var ijre = IJRegex();
        await foreach (var word in repo.GetWordsOfLength(5))
        {
            var ijCount = ijre.Matches(word).Count;
            Assert.That(word.Length, Is.EqualTo(5 + ijCount));    
        }
    }

    [GeneratedRegex(".*(ij).*")]
    private static partial Regex IJRegex();
}