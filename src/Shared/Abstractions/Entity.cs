using MW.SAXSAY.Shared.Contracts;
using MW.SAXSAY.Shared.Helpers;

namespace MW.SAXSAY.Shared.Abstractions;

public abstract class Entity : IEntity<string>
{
    public string? Id { get; init; }

    protected Entity()
    {
        Id = IdentifierGenerators.TimePlusRandomGenerator.Generate();
    }
}