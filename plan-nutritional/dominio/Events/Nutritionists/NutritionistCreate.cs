using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.ValueObjects;
using Inventory.Domain.Abstractions;

namespace Domain.Events.Nutritionists
{
    public record NutritionistCreate : DomainEvent
    {
        public Guid Id { get; init; }
        public FullName FullName { get; init; }
        public string Specialization { get; init; }

        public NutritionistCreate(Guid id, FullName fullName, string specialization)
        {
            Id = id;
            FullName = fullName;
            Specialization = specialization;
        }
    }
}
