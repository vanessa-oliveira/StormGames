using MediatR;
using StormGames.Domain.Entities;

namespace StormGames.Application.Commands.Genres;

public class CreateGenreCommand : IRequest<Genre>
{
    public string Name { get; set; }
}