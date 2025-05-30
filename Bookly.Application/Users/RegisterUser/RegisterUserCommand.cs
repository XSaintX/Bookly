﻿using Bookly.Application.Abstractions.Messaging;


namespace Bookly.Application.Users.RegisterUser
{
    public sealed record RegisterUserCommand(string Email, string FirstName, string LastName, string Password):ICommand<Guid>;
}
