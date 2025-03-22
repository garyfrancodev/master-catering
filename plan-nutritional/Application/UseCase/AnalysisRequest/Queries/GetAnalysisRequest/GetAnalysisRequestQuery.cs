using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Dto;
using MediatR;

namespace Application.UseCase.AnalysisRequest.Queries.GetAnalysisRequest
{
    public record GetAnalysisRequestQuery(string SearchTearm) : IRequest<IEnumerable<AnalysisRequestDto>>
    {
    }
}
