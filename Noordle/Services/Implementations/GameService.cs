using Noordle.Models;

namespace Noordle.Services.Implementations;

public class GameService : IGameService
{
    private readonly IGameRepository _gameRepository;
    private readonly IWordlistRepository _wordlistRepository;
    private readonly Random _random = new();

    public GameService(IGameRepository gameRepository, IWordlistRepository wordlistRepository)
    {
        _gameRepository = gameRepository;
        _wordlistRepository = wordlistRepository;
    }

    public async Task<StartGameResponse> StartGame(int boardCount, int wordLength)
    {
        var possibleWords = _wordlistRepository.GetWordsOfLength(wordLength);
        var words = new List<string>(boardCount);
        for (var i = 0; i < boardCount; i++)
        {
            words.Add(possibleWords[_random.Next(possibleWords.Count)]);
        }

        var game = new Game(wordLength, boardCount, words);
        await _gameRepository.AddOrUpdate(game);
        return new StartGameResponse(game.Id);
    }

    public async Task<GuessResponse> GuessWord(Guid gameId, string guess)
    {
        var game = await _gameRepository.GetGame(gameId);
        if (game == null)
        {
            throw new InvalidOperationException($"Game with id {gameId} does not exist");
        }
        if (guess.Length > game.WordLength)
        {
            throw new InvalidOperationException($"Guess is longer than {game.WordLength} characters");
        }

        throw new NotImplementedException();
    }
}