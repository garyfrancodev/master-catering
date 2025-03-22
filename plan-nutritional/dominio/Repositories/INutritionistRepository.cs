using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model;

namespace Domain.Repositories
{
    public interface INutritionistRepository
    {
        
        Task AddAsync(Nutritionist nutritionist);
        Task UpdateAsync(Nutritionist nutritionist);
        Task DeleteAsync(Guid id);
        Task<Nutritionist> GetByIdAsync(Guid id);
        Task<IReadOnlyList<Nutritionist>> GetAllAsync();
        Task<IReadOnlyList<Nutritionist>> GetByStatusAsync(NutritionistStatus status);
    }

}
