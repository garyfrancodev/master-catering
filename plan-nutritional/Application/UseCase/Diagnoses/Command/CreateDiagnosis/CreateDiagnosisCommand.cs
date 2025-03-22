using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCase.Diagnoses.Command.CreateDiagnosis
{
    public record CreateDiagnosisCommand(
    Guid Id,
    Guid PatientId,
    Guid ProfessionalId,
    string Details,
    DateTime Date
) : IRequest<Guid>;

}
