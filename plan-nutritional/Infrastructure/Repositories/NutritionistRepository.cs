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
    internal class NutritionistRepository : INutritionistRepository
    {
        private readonly DomainDbContext _context;

        public NutritionistRepository(DomainDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Nutritionist nutritionist)
        {
            await _context.Nutritionist.AddAsync(nutritionist);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var nutritionist = await GetByIdAsync(id);
            _context.Nutritionist.Remove(nutritionist);
            await _context.SaveChangesAsync();
        }

        public Task<IReadOnlyList<Nutritionist>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Nutritionist> GetByIdAsync(Guid id)
        {
           return await _context.Nutritionist.FindAsync(id);
        }

        public Task<IReadOnlyList<Nutritionist>> GetByStatusAsync(NutritionistStatus status)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Nutritionist nutritionist)
        {
            _context.Nutritionist.Update(nutritionist);
            return Task.CompletedTask;
        }
    }
}
