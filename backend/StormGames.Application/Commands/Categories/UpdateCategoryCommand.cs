using MediatR;
using StormGames.Domain.Entities;

namespace StormGames.Application.Commands.Categories;

public class UpdateCategoryCommand : IRequest<Category>
{
    public int Id { get; set; }
    public string Name { get; set; }
}