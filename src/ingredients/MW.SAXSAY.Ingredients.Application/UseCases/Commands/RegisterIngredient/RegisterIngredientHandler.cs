
using MediatR;
using MW.SAXSAY.Ingredients.Domain.Entities;
using MW.SAXSAY.Ingredients.Domain.Interfaces;
using MW.SAXSAY.Ingredients.Domain.ValueObjects;

namespace MW.SAXSAY.Ingredients.Application.UseCases.Commands;

public class RegisterIngredientHandler
    : IRequestHandler<RegisterIngredientCommand, IngredientId>
{
    #region Properties & Variables
    private readonly IUnitOfWorkIngredient _unitOfWorkIngredient;
    #endregion

    #region Constructor
    public RegisterIngredientHandler(IUnitOfWorkIngredient unitOfWorkIngredient)
    {
        _unitOfWorkIngredient = unitOfWorkIngredient;
    }
    #endregion // Constructor

    #region Methods
    public async Task<IngredientId> Handle(
        RegisterIngredientCommand request, CancellationToken cancellationToken)
    {
        Ingredient.IngredientBuilder ingredientBuilder = new();
        ingredientBuilder.WithDescription(request.Description);
        ingredientBuilder.WithStatusActive(isActive: true);
        Ingredient ingredient = ingredientBuilder.Build();

        IngredientId? ingredientId =
            await _unitOfWorkIngredient
                    .IngredientRepository
                    .RegisterAsync(ingredient, cancellationToken);
        await _unitOfWorkIngredient.SaveChangesAsync(cancellationToken);

        if (ingredientId is null)
            return new IngredientId(0);
        return ingredientId;
    }
    #endregion
}