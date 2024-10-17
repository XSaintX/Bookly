using Bookly.Domain.Abstractions;

namespace Bookly.Domain.Bookings.Events;

public sealed record BookingConfirmedDomainEvent(Guid BookingId) : IDomainEvent;