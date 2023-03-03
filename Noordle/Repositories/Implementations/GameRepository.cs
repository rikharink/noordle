using Noordle.Models;

namespace Noordle.Services.Implementations;

public class GameRepository : IGameRepository
{
    private readonly Dictionary<Guid, Game> _games = new();

    public Task AddOrUpdate(Game game)
    {
        if (_games.ContainsKey(game.Id))
        {
            _games[game.Id] = game;
        }
        else
        {
            _games.Add(game.Id, game);
        }
        return Task.CompletedTask;
    }

    public Task<Game?> GetGame(Guid gameId)
    {
        _games.TryGetValue(gameId, out var game);
        return Task.FromResult(game);
    }

    public Task RemoveGame(Guid gameId)
    {
        _games.Remove(gameId);
        return Task.CompletedTask;
    }
}