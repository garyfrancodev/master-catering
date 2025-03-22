using Application.Dto;
using Application.UseCase.Diagnoses.Queries;
using Infrastructure.StoredModel;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Handler.Diagnosis
{
    internal class GetDiagnosisHandler : IRequestHandler<GetDiagnosisQuery, IEnumerable<DiagnosisDto>>
    {
        private readonly StoredDbContext _storedDbContext;

        public GetDiagnosisHandler(StoredDbContext storedDbContext)
        {
            _storedDbContext = storedDbContext;
        }

        public async Task<IEnumerable<DiagnosisDto>> Handle(GetDiagnosisQuery request, CancellationToken cancellationToken)
        {
            return await _storedDbContext.Diagnosis.AsNoTracking()
                .Select(d => new DiagnosisDto
                {
                    Id = d.Id,
                    PatientId = d.PatientId,
                    ProfessionalId = d.ProfessionalId,
                    Details = d.Details, // Convertir el Value Object a string
                    Date = d.Date
                })
                .ToListAsync(cancellationToken);
        }
    }
}