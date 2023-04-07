using System.ComponentModel.DataAnnotations;

namespace Noordle.Models;

public class StartGameDto : IValidatableObject
{
    public int BoardCount { get; set; }
    public int WordLength { get; set; }
    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (BoardCount < 1)
        {
            yield return new ValidationResult("A minimum of 1 board is required to play a game",
                new[] { nameof(BoardCount) });
        }

        if (WordLength < 3)
        {
            yield return new ValidationResult("A minimum of 3 letters is required to play a game",
                new[] { nameof(WordLength) });
        }
    }
}