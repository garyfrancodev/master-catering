using Application.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCase.Consultations.Queries
{
    public record GetConsultationQuery(string SearchTearm) : IRequest<IEnumerable<ConsultationDto>>
    {
    }
}
