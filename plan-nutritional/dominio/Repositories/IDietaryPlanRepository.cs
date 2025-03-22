using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model;

namespace Domain.Repositories
{
    public interface IDietaryPlanRepository
    {
        Task AddAsync(DietaryPlan dietaryPlan);
        Task UpdateAsync(DietaryPlan dietaryPlan);
        Task DeleteAsync(Guid id);
        Task<DietaryPlan> GetByIdAsync(Guid id);
        Task<IReadOnlyList<DietaryPlan>> GetAllAsync();
        Task<IReadOnlyList<DietaryPlan>> GetByStatusAsync(PlanStatus status);
    }

}
