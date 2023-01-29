using MediatR;
using StormGames.Application.Commands.Genres;
using StormGames.Domain.Entities;
using StormGames.Infra.Contracts;

namespace StormGames.Application.Handlers.Genres;

public class UpdateGenreCommandHandler : IRequestHandler<UpdateGenreCommand, Genre>
{
    private readonly IGenreRepository _genreRepository;

    public UpdateGenreCommandHandler(IGenreRepository genreRepository)
    {
        _genreRepository = genreRepository;
    }

    public async Task<Genre> Handle(UpdateGenreCommand command, CancellationToken cancellationToken)
    {
        var genre = await _genreRepository.GetGenreById(command.Id);
        genre.UpdateGenre(command.Name);
        await _genreRepository.Update(genre);
        return genre;
    }
}