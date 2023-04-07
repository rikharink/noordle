using System.Collections.Immutable;
using Noordle.Models;

namespace Noordle.Services.Implementations;

public class GameService : IGameService
{
    private readonly IGameRepository _gameRepository;
    private readonly IWordlistRepository _wordlistRepository;
    private readonly Random _random = new();

    private ImmutableList<string> possibleWords;

    public GameService(IGameRepository gameRepository, IWordlistRepository wordlistRepository)
    {
        _gameRepository = gameRepository;
        _wordlistRepository = wordlistRepository;
    }

    public async Task<StartGameResponse> StartGame(int boardCount, int wordLength)
    {
        possibleWords = _wordlistRepository.GetWordsOfLength(wordLength).ToImmutableList();
        var words = WordSelector.SelectWords(possibleWords, boardCount);

        var game = new Game(words);
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

        if (!possibleWords.Contains(guess))
        {
            return new GuessResponse(false, Array.Empty<WordMatch>());
        }

        return game.GuessWord(guess);
    }
}