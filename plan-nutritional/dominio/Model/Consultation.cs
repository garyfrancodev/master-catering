using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory.Domain.Abstractions;

namespace Domain.Model
{
    public class Consultation : AggregateRoot
    {
        public Guid? AppointmentId { get; private set; } // Ahora es opcional (nullable)
        public Guid PatientId { get; private set; }
        public string Status { get; private set; }
        public DateTime Date { get; private set; }
        public Guid Nutritionist { get; private set; }
        public Consultation(Guid id, Guid? appointmentId, Guid patientId, string status, DateTime date, Guid nutritionist)
        {
            Id = id;
            AppointmentId = appointmentId;
            PatientId = patientId;
            Status = status;
            Date = date;
            Nutritionist = nutritionist;
        }
        public Consultation(Guid id, Guid patientId, string status, DateTime date, Guid nutritionist)
            : this(id, null, patientId, status, date, nutritionist) { }
        public void SetAppointmentId(Guid appointmentId)
        {
            AppointmentId = appointmentId;
        }
    }

}
