using MediatR;
using StormGames.Domain.Entities;

namespace StormGames.Application.Commands.Categories;

public class CreateCategoryCommand : IRequest<Category>
{
    public string Name { get; set; }
}