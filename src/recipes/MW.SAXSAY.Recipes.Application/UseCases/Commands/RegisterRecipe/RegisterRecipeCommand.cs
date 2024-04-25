using MediatR;
using MW.SAXSAY.Domain.Common;
using MW.SAXSAY.Recipes.Application.DTOs;
using MW.SAXSAY.Recipes.Domain.ValueObjects;

namespace MW.SAXSAY.Recipes.Application.UseCases.Commands;

public record RegisterRecipeCommand : RegisterRecipeDto, IRequest<BaseResponse<RecipeId>>;