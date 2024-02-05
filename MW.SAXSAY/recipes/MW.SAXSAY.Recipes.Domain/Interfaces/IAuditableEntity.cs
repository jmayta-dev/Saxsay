namespace recipes.MW.SAXSAY.Recipes.Domain.Interfaces;

public interface IAuditableEntity<TId> : IAuditableEntity, IEntity<TId>
{
    int CreatedBy { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}

public interface IAuditableEntity { }