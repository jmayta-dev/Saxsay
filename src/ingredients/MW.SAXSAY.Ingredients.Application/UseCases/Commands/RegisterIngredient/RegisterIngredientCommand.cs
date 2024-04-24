using MediatR;
using MW.SAXSAY.Domain.Common;
using MW.SAXSAY.Ingredients.Domain.ValueObjects;

namespace MW.SAXSAY.Ingredients.Application.UseCases.Commands;

public record RegisterIngredientCommand(
    string Description,
    bool IsActive,
    int BaseUnitId
) : IRequest<BaseResponse<IngredientId>>;