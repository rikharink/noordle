namespace Noordle.Models;

public class Game
{
    public int WordLength { get; }
    public Guid Id { get; } = Guid.NewGuid();
    public List<Board> Boards { get; }
    
    private int MaxGuesses { get; set; }
    private int Guesses { get; set; }

    public Game(IReadOnlyCollection<string> words)
    {
        var wordLength = words.First().Length;
        if (words.Any(w => w.Length != wordLength))
        {
            throw new InvalidOperationException("words contains words of different lengths ");
        }

        WordLength = wordLength;
        var boardCount = words.Count;
        MaxGuesses = 5 + boardCount;
        Boards = words.Select(word => new Board(word)).ToList();
    }

    public GuessResponse GuessWord(string guess)
    {
        if (Guesses == MaxGuesses)
        {
            throw new InvalidOperationException("Game over!");
        }

        var result = new List<WordMatch?>();
        foreach (var board in Boards)
        {
            var guessResponse = board.Guess(guess);
            result.Add(guessResponse);
        }
       
        Guesses++;
        return new GuessResponse(true, result.ToArray());
    }
}