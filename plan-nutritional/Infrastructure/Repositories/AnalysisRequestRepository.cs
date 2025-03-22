using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model;
using Domain.Repositories;
using Infrastructure.DomainModel;

namespace Infrastructure.Repositories
{
    internal class AnalysisRequestRepository : IAnalysisRequestRepository
    {
        private readonly DomainDbContext _context;

        public AnalysisRequestRepository(DomainDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(AnalysisRequest analysisRequest)
        {
            await _context.AnalysisRequest.AddAsync(analysisRequest);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var analysisRequest = await GetByIdAsync(id);
            _context.AnalysisRequest.Remove(analysisRequest);
            await _context.SaveChangesAsync();
        }

        public Task<IReadOnlyList<AnalysisRequest>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<AnalysisRequest> GetByIdAsync(Guid id)
        {
            return await _context.AnalysisRequest.FindAsync(id);
        }

        public Task<IReadOnlyList<AnalysisRequest>> GetByPatientIdAsync(Guid patientId)
        {
            throw new NotImplementedException();
        }
        public Task UpdateAsync(AnalysisRequest analysisRequest)
        {
            _context.AnalysisRequest.Update(analysisRequest);
            return Task.CompletedTask;
        }
    }
}
