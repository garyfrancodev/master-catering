using Application.UseCase.Nutritionists.Command.CreateNutritionist;
using Application.UseCase.Nutritionists.Command.DeleteNutritionist;
using Application.UseCase.Nutritionists.Command.EditNutritionist;
using Application.UseCase.Nutritionists.Queries.GetNutritionist;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NutritionistControllerr : ControllerBase
    {
        private readonly IMediator _mediator;

        public NutritionistControllerr(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult> CreateNutritionist([FromBody] CreateNutritionistCommand command)
        {
            try
            {
                var id = await _mediator.Send(command);

                return Ok(id);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult> GetNutritionist()
        {
            try
            {
                var result = await _mediator.Send(new GetNutritionistQuery(""));
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteNutritionist(Guid id)
        {
            try
            {
                var result = await _mediator.Send(new DeleteNutritionistCommand(id));
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPatch]
        public async Task<ActionResult> UpdateNutritionist(UpdateNutritionistCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
