using MediatR;
using StormGames.Domain.Entities;

namespace StormGames.Application.Commands.Genres;

public class DeleteGenreCommand : IRequest<Genre>
{
    public Guid Id { get; set; }
}