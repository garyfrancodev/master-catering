using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Dto;
using MediatR;

namespace Application.UseCase.Nutritionists.Queries.GetNutritionist
{
    public record GetNutritionistQuery(string SearchTearm) : IRequest<IEnumerable<NutritionistDto>>
    {
    }
}
