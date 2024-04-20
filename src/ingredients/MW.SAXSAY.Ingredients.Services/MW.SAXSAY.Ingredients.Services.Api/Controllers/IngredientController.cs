using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MW.SAXSAY.Ingredients.Application.UseCases.Commands;

namespace MW.SAXSAY.Ingredients.Services.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientController : ControllerBase
    {
        #region Properties & Variables
        //
        // private
        //
        private readonly IMediator _mediator;
        //
        // public
        //
        #endregion

        #region Constructors
        public IngredientController(IMediator mediator)
        {
            _mediator = mediator;
        }
        #endregion

        #region Methods
        [HttpPost("Register")]
        public async Task<IActionResult> RegisterIngredient([FromBody] RegisterIngredientCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }
        #endregion

    }
}
