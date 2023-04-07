using Noordle.Services.Implementations;

namespace Noordle.Models;

public class Board
{
    public Board(string word)
    {
        Word = word;
    }

    private string Word { get; }

    private bool IsWon { get; set; }

    public WordMatch? Guess(string guess)
    {
        if (IsWon)
        {
            return null;
        }

        var guessResponse = WordComparer.Compare(Word, guess);
        if (guessResponse.Letters.All(l => l == LetterStatus.Correct))
        {
            IsWon = true;
        }
        
        return guessResponse;
    }
}