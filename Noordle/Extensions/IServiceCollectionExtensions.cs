using Noordle.Services;
using Noordle.Services.Implementations;

namespace Noordle.Extensions;

public static class IServiceCollectionExtensions
{
    public static void RegisterDependencies(this IServiceCollection services)
    {
        services.AddSingleton<IGameRepository, GameRepository>();
        services.AddSingleton<IWordlistRepository, WordlistRepository>();
        services.AddSingleton<IGameService, GameService>();
    }
}