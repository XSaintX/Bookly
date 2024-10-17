using Bookly.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookly.Domain.Users.Events
{
    public record UserCreatedDomainEvent(Guid UserId):IDomainEvent;
    
    
}
