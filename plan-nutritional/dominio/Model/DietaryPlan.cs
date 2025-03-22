using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.ValueObjects;

namespace Domain.Model
{
    public class DietaryPlan
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public PlanDuration Duration { get; private set; }
        public PlanStatus Status { get; private set; }
        public List<Guid> RecipeIds { get; private set; } // Ahora es una lista de GUIDs
        public DateTime CreatedDate { get; private set; }
        public DateTime? StartDate { get; private set; }
        public DateTime? EndDate { get; private set; }

        public DietaryPlan(Guid id, string name, PlanDuration duration, DateTime createdDate)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("The name of the dietary plan cannot be null or empty.");

            Id = id;
            Name = name;
            Duration = duration;
            Status = PlanStatus.Active;
            RecipeIds = new List<Guid>();
            CreatedDate = createdDate;
            StartDate = null;
            EndDate = null;
        }

        public void AddRecipe(Guid recipeId)
        {
            if (recipeId == Guid.Empty)
                throw new ArgumentException("The recipe ID cannot be empty.");

            RecipeIds.Add(recipeId);
        }

        public void RemoveRecipe(Guid recipeId)
        {
            RecipeIds.Remove(recipeId);
        }

        public void UpdateStatus(PlanStatus newStatus)
        {
            Status = newStatus;
        }

        private DietaryPlan() { }
    }

    public enum PlanStatus
    {
        Active,
        Completed,
        Canceled
    }
}
