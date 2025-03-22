using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Application.UseCase.AnalysisRequest.Command.CreateAnalysisRequest
{
    public record CreateAnalysisRequestCommand(
        Guid Id,
        Guid PatientId,
        Guid NutritionistId,
        string status,
        DateTime Date
    ) : IRequest<Guid>;
    
    }
