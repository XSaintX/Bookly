﻿using Bookly.Domain.Abstractions;

namespace Bookly.Domain.Bookings.Events;

public sealed record BookingRejectedDomainEvent(Guid BookingId) : IDomainEvent;