using MW.CHUYA.Domain.Common.Interfaces;

namespace MW.SAXSAY.Domain.Common;

public abstract class BaseEntity<T> : IEntity<T>
{
    #region Properties & Variables
    public T? Id { get; set; }
    private readonly List<IDomainEvent> _domainEvents = new List<IDomainEvent>();

    public IReadOnlyList<IDomainEvent> DomainEvents { get => _domainEvents; }
    #endregion // Properties & Variables

    #region Methods
    protected void AddDomainEvent(IDomainEvent domainEvent) => _domainEvents.Add(domainEvent);
    protected void RemoveDomainEvent(IDomainEvent domainEvent) => _domainEvents.Remove(domainEvent);
    protected void ClearDomainEvents() => _domainEvents.Clear();
    #endregion // Methods
}