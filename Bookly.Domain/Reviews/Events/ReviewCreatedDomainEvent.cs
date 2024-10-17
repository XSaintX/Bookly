using Bookly.Domain.Abstractions;

namespace Bookly.Domain.Reviews.Events;

public sealed record ReviewCreatedDomainEvent(Guid ReviewId) : IDomainEvent;