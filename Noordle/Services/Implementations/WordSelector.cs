using System.Collections.Immutable;

namespace Noordle.Services.Implementations;

public static class WordSelector
{
    private static readonly Random Random = new();
    public static List<string> SelectWords(ImmutableList<string> possibleWords, int boardCount)
    {
        var words = new List<string>(boardCount);
        for (var i = 0; i < boardCount; i++)
        {
            words.Add(possibleWords[Random.Next(possibleWords.Count)]);
        }

        return words;
    }
}