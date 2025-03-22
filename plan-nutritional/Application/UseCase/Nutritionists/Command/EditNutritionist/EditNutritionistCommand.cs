using Domain.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCase.Nutritionists.Command.EditNutritionist
{
    public record UpdateNutritionistCommand(
    Guid Id,                     // ID del nutricionista a actualizar
    string? FullName,            // Nombre completo actualizado (opcional)
    string? Specialization,      // Especialización actualizada (opcional)
    NutritionistStatus? Status   // Estado actualizado (opcional)
) : IRequest<bool>;              // Devuelve un booleano para indicar éxito

}
