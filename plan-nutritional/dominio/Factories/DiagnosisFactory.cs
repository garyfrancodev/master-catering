using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model;
using Domain.ValueObjects;

namespace Domain.Factories
{
    public class DiagnosisFactory : IDiagnosisFactory
    {
        public Diagnosis CreateDiagnosis(
            Guid id,
            Guid patientId,
            Guid professionalId,
            DiagnosisDetails details,
            DateTime date)
        {
            if (patientId == Guid.Empty)
                throw new ArgumentException("Patient ID cannot be empty.");

            if (professionalId == Guid.Empty)
                throw new ArgumentException("Professional ID cannot be empty.");

            if (date == default)
                throw new ArgumentException("Date cannot be default value.");

            return new Diagnosis(id, patientId, professionalId, details, date);
        }
    }

}
