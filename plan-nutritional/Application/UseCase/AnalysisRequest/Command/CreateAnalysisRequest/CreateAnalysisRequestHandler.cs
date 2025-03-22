using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Factories.AnalysisRequests;
using Domain.Repositories;
using Inventory.Domain.Abstractions;
using MediatR;

namespace Application.UseCase.AnalysisRequest.Command.CreateAnalysisRequest
{
    internal class CreateAnalysisRequestHandler : IRequestHandler<CreateAnalysisRequestCommand, Guid>
    {
        private readonly IAnalysisRequestFactory _analysisRequestFactory;
        private readonly IAnalysisRequestRepository _analysisRequestRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateAnalysisRequestHandler(
            IAnalysisRequestFactory analysisRequestFactory,
            IAnalysisRequestRepository analysisRequestRepository,
            IUnitOfWork unitOfWork)
        {
            _analysisRequestFactory = analysisRequestFactory;
            _analysisRequestRepository = analysisRequestRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CreateAnalysisRequestCommand request, CancellationToken cancellationToken)
        {
            var analysisRequestId = Guid.NewGuid();
            var analysisRequest = _analysisRequestFactory.CreateAnalysisRequest(
                analysisRequestId,
                request.PatientId,
                request.NutritionistId,
                request.Date,
                request.status
            );

             await _analysisRequestRepository.AddAsync(analysisRequest);
            await _unitOfWork.CommitAsync(cancellationToken);
            return analysisRequest.Id;
        }
    }
}
