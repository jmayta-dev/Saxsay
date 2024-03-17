
using AutoMapper;
using recipes.MW.SAXSAY.Recipes.Application.DTOs;
using recipes.MW.SAXSAY.Recipes.Domain.Entities;

namespace recipes.MW.SAXSAY.Recipes.Application.UseCases.Mappings;

public class RecipeMappingProfile : Profile
{
    public RecipeMappingProfile()
    {
        CreateMap<Recipe, RecipeDto>().ReverseMap();
    }
}