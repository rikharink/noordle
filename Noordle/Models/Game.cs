namespace Noordle.Models;

public class Game
{
    public int WordLength { get; }
    public Guid Id { get; } = Guid.NewGuid();
    public List<Board> Boards { get; }

    public Game(int wordLength, int boardCount, IReadOnlyCollection<string> words)
    {
        if (words.Count > boardCount)
        {
            throw new InvalidOperationException(
                $"words has length {words.Count} but should be the same length as boardCount {boardCount}");
        }

        WordLength = wordLength;
        Boards = words.Select(word => new Board(word, 6 + boardCount - 1)).ToList();
    }
}