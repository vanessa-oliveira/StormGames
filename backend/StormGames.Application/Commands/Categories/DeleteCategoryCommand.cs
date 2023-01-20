using MediatR;
using StormGames.Domain.Entities;

namespace StormGames.Application.Commands.Categories;

public class DeleteCategoryCommand : IRequest<Category>
{
    public int Id { get; set; }
}