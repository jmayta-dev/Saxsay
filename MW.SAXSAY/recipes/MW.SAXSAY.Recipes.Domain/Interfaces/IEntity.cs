namespace recipes.MW.SAXSAY.Recipes.Domain.Interfaces;

public interface IEntity<TId> : IEntity
{
    TId Id { get; set; }
}

public interface IEntity { }