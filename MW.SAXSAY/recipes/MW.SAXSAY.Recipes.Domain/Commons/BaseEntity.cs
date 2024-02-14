using recipes.MW.SAXSAY.Recipes.Domain.Interfaces;

namespace MW.SAXSAY.recipes.MW.SAXSAY.Recipes.Domain.Commons;

public abstract class BaseEntity : IEntity
{
    #region Properties & Variables
    //
    // dependency
    //

    //
    // private
    //
    private readonly List<DomainEvent> _domainEvents = new();
    //
    // public
    //
    public IReadOnlyCollection<DomainEvent> GetDomainEvents => _domainEvents;
    #endregion

    #region Constructor

    #endregion

    #region Methods
    protected void AddDomainEvent(DomainEvent domainEvent) =>
        _domainEvents.Add(domainEvent);

    public void RemoveDomainEvent(DomainEvent domainEvent) =>
        _domainEvents.Remove(domainEvent);

    public void ClearDomainEvents() =>
        _domainEvents.Clear();
    #endregion

    #region Support IDisposable

    #endregion
}