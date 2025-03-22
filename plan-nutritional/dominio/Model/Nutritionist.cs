using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.ValueObjects;
using Inventory.Domain.Abstractions;

namespace Domain.Model
{
    public class Nutritionist : AggregateRoot
    {
        public Guid Id { get; private set; }
        public FullName FullName { get; private set; }
        public string Specialization { get; private set; }
        public NutritionistStatus Status { get; private set; }

        public Nutritionist(Guid id, FullName fullName, string specialization, NutritionistStatus status)
        {
            if (string.IsNullOrWhiteSpace(specialization))
                throw new ArgumentException("Specialization cannot be null or empty.");

            Id = id;
            FullName = fullName;
            Specialization = specialization;
            Status = status;
        }

        public void UpdateSpecialization(string newSpecialization)
        {
            if (string.IsNullOrWhiteSpace(newSpecialization))
                throw new ArgumentException("Specialization cannot be null or empty.");

            Specialization = newSpecialization;
        }
        public void UpdateFullName(FullName fullname)
        {
            FullName = fullname;
        }
        public void UpdateStatus(NutritionistStatus newStatus)
        {
            Status = newStatus;
        }

        private Nutritionist() { }
    }

    public enum NutritionistStatus
    {
        Active,
        Inactive
    }
}

