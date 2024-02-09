namespace recipes.MW.SAXSAY.Recipes.Domain.Interfaces;

public interface IAuditableEntity<TId> : IAuditableEntity, IEntity<TId>
{
    int CreatedBy { get; set; }
    DateTime CreatedAt { get; set; }
    DateTime UpdatedAt { get; set; }
}

public interface IAuditableEntity { }