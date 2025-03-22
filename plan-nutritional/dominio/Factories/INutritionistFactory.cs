using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model;
using Domain.ValueObjects;

namespace Domain.Factories
{
    public interface INutritionistFactory
    {
        Nutritionist CreateNutritionist(
            Guid id,
            FullName fullName,
            string specialization,
            NutritionistStatus status);
    }

}
