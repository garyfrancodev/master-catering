using Application.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCase.Diagnoses.Queries
{
    public record GetDiagnosisQuery(string SearchTearm) : IRequest<IEnumerable<DiagnosisDto>>
    {
    }
}
