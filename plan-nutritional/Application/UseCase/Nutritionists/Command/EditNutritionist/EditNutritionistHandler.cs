using Domain.Repositories;
using Domain.ValueObjects;
using Inventory.Domain.Abstractions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCase.Nutritionists.Command.EditNutritionist
{
    internal class UpdateNutritionistHandler : IRequestHandler<UpdateNutritionistCommand, bool>
    {
        private readonly INutritionistRepository _nutritionistRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateNutritionistHandler(
            INutritionistRepository nutritionistRepository,
            IUnitOfWork unitOfWork)
        {
            _nutritionistRepository = nutritionistRepository;
            _unitOfWork = unitOfWork;
            
        }

        public async Task<bool> Handle(UpdateNutritionistCommand request, CancellationToken cancellationToken)
        {
            var nutritionist = await _nutritionistRepository.GetByIdAsync(request.Id);

            if (nutritionist == null)
            {
                return false;
            }

            if (!string.IsNullOrWhiteSpace(request.FullName))
            {
                nutritionist.UpdateFullName(new FullName(request.FullName));
            }

            if (!string.IsNullOrWhiteSpace(request.Specialization))
            {
                nutritionist.UpdateSpecialization(request.Specialization);
            }

            if (request.Status.HasValue)
            {
                nutritionist.UpdateStatus(request.Status.Value);
            }

            // Guardar los cambios en el repositorio
            _nutritionistRepository.UpdateAsync(nutritionist);

            // Confirmar la transacción
            await _unitOfWork.CommitAsync(cancellationToken);

            return true;
        }
    }
}
