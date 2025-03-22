using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Factories.Consultations
{
    public class ConsultationFactory : IConsultationFactory
    {
        public Consultation CreateWithAppointment(
            Guid id,
            Guid appointmentId,
            Guid patientId,
            string status,
            DateTime date,
            Guid nutritionist)
        {
            if (appointmentId == Guid.Empty)
            {
                throw new ArgumentException("AppointmentId cannot be empty.", nameof(appointmentId));
            }

            return new Consultation(id, appointmentId, patientId, status, date, nutritionist);
        }

        public Consultation CreateWithoutAppointment(
            Guid id,
            Guid patientId,
            string status,
            DateTime date,
            Guid nutritionist)
        {
            return new Consultation(id, patientId, status, date, nutritionist);
        }
    }

}
