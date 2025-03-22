using Application.Dto;
using Application.UseCase.Consultations.Queries;
using Infrastructure.StoredModel;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Handler.Consultation
{

    internal class GetConsultationHandler : IRequestHandler<GetConsultationQuery, IEnumerable<ConsultationDto>>
    {
        private readonly StoredDbContext _storedDbContext;

        public GetConsultationHandler(StoredDbContext storedDbContext)
        {
            _storedDbContext = storedDbContext;
        }

        public async Task<IEnumerable<ConsultationDto>> Handle(GetConsultationQuery request, CancellationToken cancellationToken)
        {
            return await _storedDbContext.Consultation.AsNoTracking()
                .Select(c => new ConsultationDto
                {
                    Id = c.Id,
                    PatientId = c.PatientId,
                    NutritionistId = c.NutritionistId,
                    Status = c.Status,
                    Date = c.Date,
                    AppointmentId = c.AppointmentId
                })
                .ToListAsync(cancellationToken);
        }
    }

}
