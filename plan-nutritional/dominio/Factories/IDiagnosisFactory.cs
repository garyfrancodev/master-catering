using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model;
using Domain.ValueObjects;

namespace Domain.Factories
{
    public interface IDiagnosisFactory
    {
        Diagnosis CreateDiagnosis(
            Guid id,
            Guid patientId,
            Guid professionalId,
            DiagnosisDetails details,
            DateTime date);
    }

}
