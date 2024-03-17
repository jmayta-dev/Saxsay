using MediatR;
using recipes.MW.SAXSAY.Recipes.Application.DTOs;
using recipes.MW.SAXSAY.Recipes.Domain.Entities;

namespace recipes.MW.SAXSAY.Recipes.Application.Commands.DeleteRecipe;

public record DeleteRecipe(
        RecipeId Id // lo que manda
); // lo que retorna