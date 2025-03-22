using Domain.Repositories;
using Inventory.Domain.Abstractions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCase.Nutritionists.Command.DeleteNutritionist
{
    internal class DeleteNutritionistHandler : IRequestHandler<DeleteNutritionistCommand, bool>
    {
        private readonly INutritionistRepository _nutritionistRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteNutritionistHandler(
            INutritionistRepository nutritionistRepository,
            IUnitOfWork unitOfWork)
        {
            _nutritionistRepository = nutritionistRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DeleteNutritionistCommand request, CancellationToken cancellationToken)
        {
            // Buscar el nutricionista en el repositorio
            var nutritionist = await _nutritionistRepository.GetByIdAsync(request.Id);

            if (nutritionist == null)
            {
                return false;
            }

            // Eliminar el nutricionista
            _nutritionistRepository.DeleteAsync(nutritionist.Id);

            // Confirmar la transacción
            await _unitOfWork.CommitAsync(cancellationToken);

            return true;
        }
    }
}