using Bookly.Domain.Abstractions;

namespace Bookly.Domain.Bookings.Events
{
    public record BookingReservedDomainEvent(Guid BookingId):IDomainEvent;
    
    
}
