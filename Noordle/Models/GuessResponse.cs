namespace Noordle.Models;

public record GuessResponse(bool IsValid, WordMatch?[] Matches);