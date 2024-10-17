using Bookly.Domain.Abstractions;

namespace Bookly.Domain.Bookings.Events;

public sealed record BookingCompletedDomainEvent(Guid BookingId) : IDomainEvent;