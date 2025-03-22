using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IConsultationRepository
    {
        Task AddAsync(Consultation consultation);
        Task UpdateAsync(Consultation consultation);
        Task DeleteAsync(Guid id);
        Task<Consultation> GetByIdAsync(Guid id);
        Task<IReadOnlyList<Consultation>> GetAllAsync();
        Task<IReadOnlyList<Consultation>> GetByPatientIdAsync(Guid patientId);
    }
}
