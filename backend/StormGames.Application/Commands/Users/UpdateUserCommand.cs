﻿using MediatR;
using StormGames.Domain.Entities;

namespace StormGames.Application.Commands.Users;

public class UpdateUserCommand : IRequest<User>
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public DateTime DateOfBirth { get; set; }
}