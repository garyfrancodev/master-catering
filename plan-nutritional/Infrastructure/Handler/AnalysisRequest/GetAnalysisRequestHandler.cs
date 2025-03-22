using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Dto;
using Application.UseCase.AnalysisRequest.Queries.GetAnalysisRequest;
using Infrastructure.StoredModel;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Handler.AnalysisRequest
{
    internal class GetAnalysisRequestHandler : IRequestHandler<GetAnalysisRequestQuery, IEnumerable<AnalysisRequestDto>>
    {
        private readonly StoredDbContext _storedDbContext;

        public GetAnalysisRequestHandler(StoredDbContext storedDbContext)
        {
            _storedDbContext = storedDbContext;
        }

        public async Task<IEnumerable<AnalysisRequestDto>> Handle(GetAnalysisRequestQuery request, CancellationToken cancellationToken)
        {
            return await _storedDbContext.AnalysisRequest.AsNoTracking()
                .Select(a => new AnalysisRequestDto
                {
                    Id = a.Id,
                    PatientId = a.patientId,
                    NutritionistId = a.NutritionistId,
                    Date = a.Date,
                    Status = a.Status
                })
                .ToListAsync(cancellationToken);
        }
    }
}
