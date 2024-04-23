namespace MW.SAXSAY.Domain.Common;

public abstract class BaseEvent
{
    public Guid EventId { get; init; } = Guid.NewGuid();
    public DateTime DateOccurred { get; protected set; } = DateTime.UtcNow;
}