using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model;

namespace Domain.Repositories
{
    public interface IDiagnosisRepository
    {
        Task AddAsync(Diagnosis diagnosis);
        Task UpdateAsync(Diagnosis diagnosis);
        Task DeleteAsync(Guid id);
        Task<Diagnosis> GetByIdAsync(Guid id);
        Task<IReadOnlyList<Diagnosis>> GetAllAsync();
        Task<IReadOnlyList<Diagnosis>> GetByPatientIdAsync(Guid patientId);
    }

}
