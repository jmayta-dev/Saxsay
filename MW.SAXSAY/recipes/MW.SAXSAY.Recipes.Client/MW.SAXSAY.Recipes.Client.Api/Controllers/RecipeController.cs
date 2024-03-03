using MediatR;
using Microsoft.AspNetCore.Mvc;
using recipes.MW.SAXSAY.Recipes.Application.UseCases.Queries.GetAllQuery;
using recipes.MW.SAXSAY.Recipes.Application.UseCases.Queries.GetByIdQuery;

namespace recipes.MW.SAXSAY.Recipes.Client.MW.SAXSAY.Recipes.Client.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RecipeController : ControllerBase
{
    private readonly IMediator _mediator;

    public RecipeController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllRecipes()
    {
        var response = await _mediator.Send(new GetAllRecipesQuery());
        return Ok(response);
    }

    [HttpGet("{recipeId:int}")]
    public async Task<IActionResult> GetRecipeById(int recipeId)
    {
        var response = await _mediator.Send(new GetRecipeByIdQuery(recipeId));
        if (response?.Id is null)
            return NotFound();
        return Ok(response);
    }
}

