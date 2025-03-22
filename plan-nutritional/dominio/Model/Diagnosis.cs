using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.ValueObjects;
using Inventory.Domain.Abstractions;

namespace Domain.Model
{
    public class Diagnosis : AggregateRoot
    {
        public Guid Id { get; private set; }
        public Guid PatientId { get; private set; }
        public Guid ProfessionalId { get; private set; }
        public DiagnosisDetails Details { get; private set; }
        public DateTime Date { get; private set; }

        public Diagnosis(Guid id, Guid patientId, Guid professionalId, DiagnosisDetails details, DateTime date)
        {
            Id = id;
            PatientId = patientId;
            ProfessionalId = professionalId;
            Details = details;
            Date = date;
        }

        public void UpdateDetails(DiagnosisDetails newDetails)
        {

            Details = newDetails;
        }

        private Diagnosis() { }
    }
}
