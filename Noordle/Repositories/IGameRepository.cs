using Noordle.Models;

namespace Noordle.Services;

public interface IGameRepository
{
    Task AddOrUpdate(Game game);
    Task<Game?> GetGame(Guid gameId);
    Task RemoveGame(Guid gameId);
}