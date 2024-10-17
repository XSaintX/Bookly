using Bookly.Domain.Abstractions;

namespace Bookly.Domain.Bookings.Events;

public sealed record BookingCancelledDomainEvent(Guid BookingId) : IDomainEvent;