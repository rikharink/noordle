using System.Collections.Immutable;
using Noordle.Services.Implementations;

namespace Noordle.Test.Services;

public class WordSelectorTest
{
    private ImmutableList<string> possibleWords;

    [SetUp]
    public void Setup()
    {
        possibleWords = ImmutableList.Create("Aarde",
            "Appel",
            "Boter",
            "Braam",
            "Druif",
            "Dader");
    }
    
    [Test]
    public void SelectWords()
    {
        var words = WordSelector.SelectWords(possibleWords, 2);

        foreach (var word in words)
        {
            Assert.IsTrue(possibleWords.Contains(word));
        }
    }
}