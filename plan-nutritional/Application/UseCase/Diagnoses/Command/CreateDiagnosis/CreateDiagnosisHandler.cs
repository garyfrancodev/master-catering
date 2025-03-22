using Domain.Model;
using Domain.Repositories;
using Domain.ValueObjects;
using Inventory.Domain.Abstractions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCase.Diagnoses.Command.CreateDiagnosis
{
    internal class CreateDiagnosisHandler : IRequestHandler<CreateDiagnosisCommand, Guid>
    {
        private readonly IDiagnosisRepository _diagnosisRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateDiagnosisHandler(IDiagnosisRepository diagnosisRepository, IUnitOfWork unitOfWork)
        {
            _diagnosisRepository = diagnosisRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CreateDiagnosisCommand request, CancellationToken cancellationToken)
        {
            var diagnosis = new Diagnosis(
                id: request.Id,
                patientId: request.PatientId,
                professionalId: request.ProfessionalId,
                details: new DiagnosisDetails(request.Details),
                date: request.Date
            );

            await _diagnosisRepository.AddAsync(diagnosis);

            await _unitOfWork.CommitAsync(cancellationToken);

            return diagnosis.Id;
        }
    }

}
