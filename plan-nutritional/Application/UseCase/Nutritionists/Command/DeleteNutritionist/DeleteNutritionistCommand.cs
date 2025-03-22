using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCase.Nutritionists.Command.DeleteNutritionist
{
    public record DeleteNutritionistCommand(
    Guid Id // ID del nutricionista a eliminar
) : IRequest<bool>; // Devuelve un booleano indicando si la operación fue exitosa

}
