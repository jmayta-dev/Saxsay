using System.Data;
using MediatR;
using MW.SAXSAY.Domain.Common;
using MW.SAXSAY.RawMaterials.Application.DTO;
using MW.SAXSAY.RawMaterials.Domain.Interfaces;

namespace MW.SAXSAY.RawMaterials.Application.UseCases.Queries;

public class GetAllIngredientsQueryHandler : IRequestHandler<GetAllIngredientsQuery, BaseResponse<IEnumerable<RawMaterialDto>>>
{
    private readonly IUnitOfWorkIngredient _unitOfWorkIngredient;

    public GetAllIngredientsQueryHandler(IUnitOfWorkIngredient unitOfWorkIngredient)
    {
        _unitOfWorkIngredient =
            unitOfWorkIngredient ??
            throw new ArgumentNullException(nameof(unitOfWorkIngredient));
    }

    public async Task<BaseResponse<IEnumerable<RawMaterialDto>>> Handle(GetAllIngredientsQuery request, CancellationToken cancellationToken)
    {
        var response = new BaseResponse<IEnumerable<RawMaterialDto>>();
        try
        {
            var ingredients =
                await _unitOfWorkIngredient
                        .IngredientRepository
                        .GetAllAsync(cancellationToken);

            if (ingredients is not null)
            {
                // parse Ingredient to IngredientDto
                List<RawMaterialDto> ingredientsDto =
                ingredients.Select(
                    i => new RawMaterialDto(i.Id!.Value, i.Description, i.IsActive, i.BaseUnitId)
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