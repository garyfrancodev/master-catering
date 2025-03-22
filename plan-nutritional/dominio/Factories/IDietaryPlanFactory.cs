using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model;
using Domain.ValueObjects;

namespace Domain.Factories
{
    public interface IDietaryPlanFactory
    {
        DietaryPlan CreateDietaryPlan(
            Guid id,
            string name,
            PlanDuration duration,
            DateTime createdDate,
            List<Guid> recipes);
    }

}
