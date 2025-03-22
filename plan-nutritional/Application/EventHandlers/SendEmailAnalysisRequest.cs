using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Events.AnalysisRequests;
using Domain.Repositories;
using Inventory.Domain.Abstractions;
using MediatR;

namespace Application.EventHandlers
{
    internal class SendEmailAnalysisRequest : INotificationHandler<AnalysisRequestCreated>
    {
        private readonly IAnalysisRequestRepository _analysisRequestRepository;
        private readonly IUnitOfWork _unitOfWork;

        public SendEmailAnalysisRequest(IAnalysisRequestRepository analysisRequestRepository, IUnitOfWork unitOfWork)
        {
            _analysisRequestRepository = analysisRequestRepository;
            _unitOfWork = unitOfWork;
        }


        public async Task Handle(AnalysisRequestCreated notification, CancellationToken cancellationToken)
        {
            
            var analysisRequest = await _analysisRequestRepository.GetByIdAsync(notification.Id);

            
            Console.WriteLine($"Enviando correo para la solicitud de análisis {notification.Id}");

            
            await _unitOfWork.CommitAsync(cancellationToken);
        }
    }
}
