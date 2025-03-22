using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model;
using Domain.ValueObjects;

namespace Domain.Factories
{

    public class NutritionistFactory : INutritionistFactory
    {
        public Nutritionist CreateNutritionist(
            Guid id,
            FullName fullName,
            string specialization,
            NutritionistStatus status)
        {
            if (string.IsNullOrWhiteSpace(specialization))
                throw new ArgumentException("Specialization cannot be null or empty.");

            return new Nutritionist(id, fullName, specialization, status);
        }
    }

}
