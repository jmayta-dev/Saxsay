using System.Data;
using MediatR;
using MW.SAXSAY.Domain.Common;
using MW.SAXSAY.Ingredients.Application.DTO;
using MW.SAXSAY.Ingredients.Domain.Interfaces;

namespace MW.SAXSAY.Ingredients.Application.UseCases.Queries;

public class GetAllIngredientsQueryHandler : IRequestHandler<GetAllIngredientsQuery, BaseResponse<IEnumerable<IngredientDto>>>
{
    private readonly IUnitOfWorkIngredient _unitOfWorkIngredient;

    public GetAllIngredientsQueryHandler(IUnitOfWorkIngredient unitOfWorkIngredient)
    {
        _unitOfWorkIngredient =
            unitOfWorkIngredient ??
            throw new ArgumentNullException(nameof(unitOfWorkIngredient));
    }

    public async Task<BaseResponse<IEnumerable<IngredientDto>>> Handle(GetAllIngredientsQuery request, CancellationToken cancellationToken)
    {
        var response = new BaseResponse<IEnumerable<IngredientDto>>();
        try
        {
            var ingredients =
                await _unitOfWorkIngredient
                        .IngredientRepository
                        .GetAllAsync(cancellationToken);

            if (ingredients is not null)
            {
                // parse Ingredient to IngredientDto
                List<IngredientDto> ingredientsDto =
                ingredients.Select(
                    i => new IngredientDto(i.Id!.Value, i.Description, i.IsActive, i.BaseUnitId)
                ).ToList();

                response.IsSuccess = true;
                response.Data = ingredientsDto;
                response.Message = "Success!";
            }
        }
        catch (Exception ex)
        {
            response.Message = ex.Message;
            throw;
        }
        return response;
    }
}