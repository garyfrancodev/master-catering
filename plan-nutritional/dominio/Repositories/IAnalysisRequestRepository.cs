using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model;

namespace Domain.Repositories
{
    public interface IAnalysisRequestRepository
    {
        Task AddAsync(AnalysisRequest analysisRequest);
        Task UpdateAsync(AnalysisRequest analysisRequest);
        Task DeleteAsync(Guid id);
        Task<AnalysisRequest> GetByIdAsync(Guid id);
        Task<IReadOnlyList<AnalysisRequest>> GetAllAsync();
        Task<IReadOnlyList<AnalysisRequest>> GetByPatientIdAsync(Guid patientId);
    }
}
