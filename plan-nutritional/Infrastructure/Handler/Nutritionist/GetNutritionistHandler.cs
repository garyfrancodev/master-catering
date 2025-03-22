using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.UseCase.Nutritionists.Queries.GetNutritionist;
using Application.Dto;
using MediatR;
using Infrastructure.StoredModel;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Handler.Nutritionist
{
    internal class GetNutritionistHandler : IRequestHandler<GetNutritionistQuery, IEnumerable<NutritionistDto>>
    {
        private readonly StoredDbContext _storedDbContext;

        public GetNutritionistHandler(StoredDbContext storedDbContext)
        {
            _storedDbContext = storedDbContext;
        }
        public async Task<IEnumerable<NutritionistDto>> Handle(GetNutritionistQuery request, CancellationToken cancellationToken)
        {
            return await _storedDbContext.Nutritionist.AsNoTracking()
                .Select(n => new NutritionistDto
                {
                    Id = n.Id,
                    FullName = n.FullName,
                    Specialization = n.Specialization,
                    Status = n.Status
                })
                .ToListAsync(cancellationToken);
        }
    }
}
