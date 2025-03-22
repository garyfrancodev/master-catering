using Domain.Factories.Consultations;
using Domain.Repositories;
using Inventory.Domain.Abstractions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCase.Consultations.Command.CreateConsultation
{
    internal class CreateConsultationHandler : IRequestHandler<CreateConsultationCommand, Guid>
    {
        private readonly IConsultationFactory _consultationFactory;
        private readonly IConsultationRepository _consultationRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateConsultationHandler(
            IConsultationFactory consultationFactory,
            IConsultationRepository consultationRepository,
            IUnitOfWork unitOfWork)
        {
            _consultationFactory = consultationFactory;
            _consultationRepository = consultationRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CreateConsultationCommand request, CancellationToken cancellationToken)
        {
            var consultationId = Guid.NewGuid();

            var consultation = request.AppointmentId.HasValue
                ? _consultationFactory.CreateWithAppointment(
                    consultationId,
                    request.AppointmentId.Value,
                    request.PatientId,
                    request.Status,
                    request.Date,
                    request.NutritionistId)
                : _consultationFactory.CreateWithoutAppointment(
                    consultationId,
                    request.PatientId,
                    request.Status,
                    request.Date,
                    request.NutritionistId);

            await _consultationRepository.AddAsync(consultation);

            await _unitOfWork.CommitAsync(cancellationToken);

            return consultation.Id;
        }
    }

}
