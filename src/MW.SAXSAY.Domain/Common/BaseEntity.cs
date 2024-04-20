using MW.CHUYA.Domain.Common.Interfaces;

namespace MW.SAXSAY.Domain;

public abstract class BaseEntity<T> : IEntity<T>
{
    public T? Id { get; set; }

    private readonly List<IDomainEvent> _domainEvents = new List<IDomainEvent>();
    public IReadOnlyList<IDomainEvent> DomainEvents { get => _domainEvents; }

    protected void AddDomainEvent(IDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }
}