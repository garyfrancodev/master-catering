using Application.UseCase.Consultations.Command.CreateConsultation;
using Application.UseCase.Consultations.Queries;
using Application.UseCase.Diagnoses.Command.CreateDiagnosis;
using Application.UseCase.Diagnoses.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiagnosisController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DiagnosisController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult> CreateDiagnosis([FromBody] CreateDiagnosisCommand command)
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
        public async Task<ActionResult> GetDiagnosis()
        {
            try
            {
                var result = await _mediator.Send(new GetDiagnosisQuery(""));
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}

