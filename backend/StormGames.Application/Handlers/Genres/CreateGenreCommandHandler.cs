using MediatR;
using StormGames.Application.Commands.Genres;
using StormGames.Domain.Entities;
using StormGames.Infra.Contracts;

namespace StormGames.Application.Handlers.Genres;

public class CreateGenreCommandHandler : IRequestHandler<CreateGenreCommand, Genre>
{
    private readonly IGenreRepository _genreRepository;

    public CreateGenreCommandHandler(IGenreRepository genreRepository)
    {
        _genreRepository = genreRepository;
    }

    public async Task<Genre> Handle(CreateGenreCommand command, CancellationToken cancellationToken)
    {
        var genre = new Genre
        {
            Name = command.Name
        };
        await _genreRepository.Insert(genre);
        return genre;
    }
}