using MediatR;
using MW.SAXSAY.Ingredients.Domain.ValueObjects;

namespace MW.SAXSAY.Ingredients.Application.UseCases.Commands;

public record RegisterIngredientCommand(
    string Description,
    bool IsActive
) : IRequest<IngredientId>;