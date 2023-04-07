using System.Collections;
using Noordle.Models;

namespace Noordle.Services.Implementations;

public static class WordComparer
{
    public static bool IsMatch(string wordA, string wordB) => wordA.Equals(wordB, StringComparison.OrdinalIgnoreCase);

    public static WordMatch Compare(string word, string guess)
    {
        if (IsMatch(word, guess))
        {
            var match = Enumerable.Repeat(LetterStatus.Correct, word.Length).ToArray();
            return new WordMatch(match);
        }
        
        var wordLetters = word.ToLower().ToCharArray();
        var guessLetters = guess.ToLower().ToCharArray();
        var matches = new List<LetterStatus>(guess.Length);

        var matchedLetters = new List<char>();

        for (var i = 0; i < guessLetters.Length; i++)
        {
            var guessLetter = guessLetters[i];

            var matchesCount = matchedLetters.Count(l => l == guessLetter);
            var wordCount = word.ToLower().Count(l => l == guessLetter);

            if (wordLetters[i] == guessLetter)
            {
                matches.Add(LetterStatus.Correct);
                matchedLetters.Add(guessLetter);
            }
            else if (wordLetters.Contains(guessLetter) && (!matchedLetters.Contains(guessLetter) ||
                                                           matchesCount < wordCount))
            {
                matches.Add(LetterStatus.IncorrectLocation);
                matchedLetters.Add(guessLetter);
            }
            else
            {
                matches.Add(LetterStatus.Incorrect);
            }
        }

        return new WordMatch(matches.ToArray());
    }
}