using Domain.Model;
using Domain.Repositories;
using Infrastructure.DomainModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    internal class ConsultationRepository : IConsultationRepository
    {
        private readonly DomainDbContext _context;

        public ConsultationRepository(DomainDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Consultation consultation)
        {
            await _context.Consultation.AddAsync(consultation);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var consultation = await GetByIdAsync(id);
            if (consultation == null)
            {
                throw new KeyNotFoundException($"Consultation with ID {id} not found.");
            }

            _context.Consultation.Remove(consultation);
            await _context.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<Consultation>> GetAllAsync()
        {
            return await _context.Consultation.AsNoTracking().ToListAsync();
        }

        public async Task<Consultation> GetByIdAsync(Guid id)
        {
            var consultation = await _context.Consultation.FindAsync(id);
            if (consultation == null)
            {
                throw new KeyNotFoundException($"Consultation with ID {id} not found.");
            }

            return consultation;
        }

        public Task<IReadOnlyList<Consultation>> GetByPatientIdAsync(Guid patientId)
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyList<Consultation>> GetByStatusAsync(string status)
        {
            return await _context.Consultation
                .AsNoTracking()
                .Where(c => c.Status == status)
                .ToListAsync();
        }

        public async Task UpdateAsync(Consultation consultation)
        {
            _context.Consultation.Update(consultation);
            await _context.SaveChangesAsync();
        }
    }

}
