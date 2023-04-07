using Noordle.Services.Implementations;

namespace Noordle.Models;

public class Board
{
    public Board(string word, int maxGuesses)
    {
        Word = word;
        MaxGuesses = maxGuesses;
    }
    
    public string Word { get; }
    public int MaxGuesses { get; }
    public int Guesses { get; set; }
    
    public bool IsWon { get; set; }

    public WordMatch? Guess(string guess)
    {
        if (Guesses == MaxGuesses)
        {
            throw new InvalidOperationException("Game over!");
        }
        if (IsWon)
        {
            return null;
        }

        var guessResponse = WordComparer.Compare(Word, guess);
        if (guessResponse.Letters.All(l => l == LetterStatus.Correct))
        {
            IsWon = true;
        }

        Guesses++;
        return guessResponse;
    }
}