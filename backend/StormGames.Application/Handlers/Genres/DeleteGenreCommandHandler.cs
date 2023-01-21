using MediatR;
using StormGames.Application.Commands.Genres;
using StormGames.Domain.Entities;
using StormGames.Infra.Contracts;

namespace StormGames.Application.Handlers.Genres;

public class DeleteGenreCommandHandler : IRequestHandler<DeleteGenreCommand, Genre>
{
    private readonly IGenreRepository _genreRepository;

    public DeleteGenreCommandHandler(IGenreRepository genreRepository)
    {
        _genreRepository = genreRepository;
    }

    public async Task<Genre> Handle(DeleteGenreCommand command, CancellationToken cancellationToken)
    {
        var genre = await _genreRepository.GetGenreById(command.Id);
        _genreRepository.Delete(genre);
        return genre;
    }
}