using Microsoft.AspNetCore.Mvc;
using Noordle.Models;
using Noordle.Services;

namespace Noordle.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GameController : ControllerBase
{
    private readonly IGameService _gameService;

    public GameController(IGameService gameService)
    {
        _gameService = gameService;
    }

    [HttpPost]
    public async Task<ActionResult<StartGameResponse>> StartNewGame([FromBody] StartGameDto dto)
    {
        var gameId = await _gameService.StartGame(dto.BoardCount, dto.WordLength);
        return Ok(gameId);
    }

    [HttpPut("{gameId:guid}/{guess}")]
    public async Task<ActionResult<GuessResponse>> GuessWord(Guid gameId, string guess)
    {
        var response = await _gameService.GuessWord(gameId, guess);

        return Ok(response);
    }
    
    [HttpDelete("{gameId:guid}")]
    public async Task<ActionResult> EndGame(Guid gameId)
    {
        await _gameService.EndGame(gameId);

        return Ok();
    }
}