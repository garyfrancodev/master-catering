using Application.UseCase.AnalysisRequest.Command.CreateAnalysisRequest;
using Application.UseCase.AnalysisRequest.Queries.GetAnalysisRequest;
using Application.UseCase.Consultations.Command.CreateConsultation;
using Application.UseCase.Consultations.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultationController : ControllerBase
    {
        private readonly IMediator _mediator;

    public ConsultationController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<ActionResult> CreateConsultation([FromBody] CreateConsultationCommand command)
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
    public async Task<ActionResult> GetConsultations()
    {
        try
        {
            var result = await _mediator.Send(new GetConsultationQuery(""));
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
}
}

