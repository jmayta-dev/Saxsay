using AutoMapper;
using MW.SAXSAY.Recipes.Application.DTOs;
using MW.SAXSAY.Recipes.Domain.Entities;

namespace recipes.MW.SAXSAY.Recipes.Application.UseCases.Mappings;

public class RecipeMappingProfile : Profile
{
    public RecipeMappingProfile()
    {
        CreateMap<Recipe, RecipeDto>().ReverseMap();
    }
}