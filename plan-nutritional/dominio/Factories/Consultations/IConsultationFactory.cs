using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Factories.Consultations
{
    public interface IConsultationFactory
    {
        Consultation CreateWithAppointment(
            Guid id,
            Guid appointmentId,
            Guid patientId,
            string status,
            DateTime date,
            Guid nutritionist);

        Consultation CreateWithoutAppointment(
            Guid id,
            Guid patientId,
            string status,
            DateTime date,
            Guid nutritionist);
    }

}
