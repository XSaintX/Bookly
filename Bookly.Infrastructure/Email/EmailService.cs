using Bookly.Application.Abstractions.Email;
using Bookly.Domain.Users;

namespace Bookly.Infrastructure.Email
{
    internal sealed class EmailService:IEmailService
    {
        public Task SendAsync(Domain.Users.Email email, string subject, string body)
        {
            return Task.CompletedTask;
        }
    }
}
