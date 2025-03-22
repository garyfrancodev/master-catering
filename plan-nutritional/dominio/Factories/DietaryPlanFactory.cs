using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model;
using Domain.ValueObjects;

namespace Domain.Factories
{
    public class DietaryPlanFactory : IDietaryPlanFactory
    {
        public DietaryPlan CreateDietaryPlan(
            Guid id,
            string name,
            PlanDuration duration,
            DateTime createdDate,
            List<Guid> recipes)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("The name of the dietary plan cannot be null or empty.");

            if (recipes == null || recipes.Count == 0)
                throw new ArgumentException("A dietary plan must have at least one assigned recipe.");

            var dietaryPlan = new DietaryPlan(id, name, duration, createdDate);

            foreach (var recipe in recipes)
            {
                dietaryPlan.AddRecipe(recipe);
            }

            return dietaryPlan;
        }
    }

}
