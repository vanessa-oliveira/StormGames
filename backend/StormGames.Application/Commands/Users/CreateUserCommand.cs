using System.ComponentModel.DataAnnotations;
using MediatR;
using StormGames.Domain.Entities;

namespace StormGames.Application.Commands.Users;

public class CreateUserCommand : IRequest<User>
{
    [Required(ErrorMessage = "Campo {0} é obrigatório!")]
    public string FirstName { get; set; }
    [Required(ErrorMessage = "Campo {0} é obrigatório!")]
    public string LastName { get; set; }
    [Required(ErrorMessage = "Campo {0} é obrigatório!")]
    public DateTime DateOfBirth { get; set; }
    [Required(ErrorMessage = "Campo {0} é obrigatório!")]
    [EmailAddress]
    public string Email { get; set; }
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [DataType(DataType.Password)]
    [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 5)]
    public string Password { get; set; }
    public string Role { get; set; }
}