using MediatR;
using StormGames.Application.Commands.Games;
using StormGames.Application.Commands.Genres;
using StormGames.Application.Queries;
using StormGames.Infra.Contracts;
using StormGames.Infra.Repositories;

namespace StormGames.API.Configuration;

public static class AppConfiguration
{
    public static IServiceCollection AddConfig(this IServiceCollection services)
    {
        services.AddMediatR(typeof(CreateGenreCommand));
        services.AddMediatR(typeof(UpdateGenreCommand));
        services.AddMediatR(typeof(DeleteGenreCommand));
        services.AddMediatR(typeof(CreateGameCommand));
        services.AddMediatR(typeof(UpdateGameCommand));
        services.AddMediatR(typeof(DeleteGameCommand));
        services.AddRepositories();
        return services;
    }

    private static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddTransient<IGenreRepository, GenreRepository>();
        services.AddTransient<IGenreQueries, GenreQueries>();
        services.AddTransient<IGameRepository, GameRepository>();
        services.AddTransient<IGameQueries, GameQueries>();
        return services;
    }
}