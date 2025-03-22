using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model;
using MediatR;

namespace Application.UseCase.Nutritionists.Command.CreateNutritionist
{
        public record CreateNutritionistCommand(
            Guid Id,
            string FullName,
            string Specialization,
            NutritionistStatus Status
        ) : IRequest<Guid>;
}
