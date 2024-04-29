using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MW.SAXSAY.RawMaterials.Application.UseCases.Commands;
using MW.SAXSAY.RawMaterials.Application.UseCases.Queries;

namespace MW.SAXSAY.RawMaterials.Services.Api.Controllers
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
        [HttpGet]
        public async Task<IActionResult> ListIngredients()
        {
            var response = await _mediator.Send(new GetAllIngredientsQuery());
            return Ok(response);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterIngredient([FromBody] RegisterRawMaterialCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }
        #endregion

    }
}
