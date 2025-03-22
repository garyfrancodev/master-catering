using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCase.Consultations.Command.CreateConsultation
{
    public record CreateConsultationCommand(
    Guid Id,
    Guid PatientId,
    Guid NutritionistId,
    string Status,
    DateTime Date,
    Guid? AppointmentId
) : IRequest<Guid>;

}
