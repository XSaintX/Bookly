using Bookly.Application.Abstractions.Clock;

namespace Bookly.Infrastructure.Clock
{
    internal sealed class DateTimeProvider:IDateTimeProvider
    {
        public DateTime UtcNow => DateTime.UtcNow;
    }
}
