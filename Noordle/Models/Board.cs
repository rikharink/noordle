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
}