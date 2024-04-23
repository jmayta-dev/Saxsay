
using MediatR;
using MW.SAXSAY.Domain.Common;
using MW.SAXSAY.Ingredients.Application.DTO;

namespace MW.SAXSAY.Ingredients.Application.UseCases.Queries;

public record GetAllIngredientsQuery()
    : IRequest<BaseResponse<IEnumerable<IngredientDto>>>;