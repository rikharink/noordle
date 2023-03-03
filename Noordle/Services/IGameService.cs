using Noordle.Models;

namespace Noordle.Services;

public interface IGameService
{
    Task<StartGameResponse> StartGame(int boardCount, int wordLength);
    Task<GuessResponse> GuessWord(Guid gameId, string guess);
}