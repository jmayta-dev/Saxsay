using MediatR;

namespace MW.SAXSAY.recipes.MW.SAXSAY.Recipes.Domain.Commons;

public record DomainEvent(Guid Id) : INotification;