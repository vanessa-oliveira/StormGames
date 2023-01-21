using MediatR;
using StormGames.Domain.Entities;

namespace StormGames.Application.Commands.Genres;

public class UpdateGenreCommand : IRequest<Genre>
{
    public int Id { get; set; }
    public string Name { get; set; }
}