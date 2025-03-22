using Domain.Model;
using Domain.Repositories;
using Infrastructure.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    internal class DiagnosisRepository : IDiagnosisRepository
    {
        private readonly DomainDbContext _context;

        public DiagnosisRepository(DomainDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Diagnosis diagnosis)
        {
            await _context.Diagnosis.AddAsync(diagnosis);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var diagnosis = await GetByIdAsync(id);
            if (diagnosis == null)
            {
                throw new KeyNotFoundException($"Diagnosis with ID {id} not found.");
            }

            _context.Diagnosis.Remove(diagnosis);
            await _context.SaveChangesAsync();
        }

        public Task<IReadOnlyList<Diagnosis>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Diagnosis> GetByIdAsync(Guid id)
        {
            var diagnosis = await _context.Diagnosis.FindAsync(id);
            if (diagnosis == null)
            {
                throw new KeyNotFoundException($"Diagnosis with ID {id} not found.");
            }

            return diagnosis;
        }

        public Task<IReadOnlyList<Diagnosis>> GetByPatientIdAsync(Guid patientId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Diagnosis diagnosis)
        {
            _context.Diagnosis.Update(diagnosis);
            return Task.CompletedTask;
        }
    }
}
