using Application.UseCase.AnalysisRequest.Command.CreateAnalysisRequest;
using Application.UseCase.AnalysisRequest.Queries.GetAnalysisRequest;
using Application.UseCase.Nutritionists.Queries.GetNutritionist;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnalysisRequestController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AnalysisRequestController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult> CreateAnalysisRequest([FromBody] CreateAnalysisRequestCommand command)
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
                var result = await _mediator.Send(new GetAnalysisRequestQuery(""));
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


    }
    }
