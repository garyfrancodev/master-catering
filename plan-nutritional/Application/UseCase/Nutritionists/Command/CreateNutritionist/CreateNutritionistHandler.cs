using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Factories;
using Domain.Model;
using Domain.Repositories;
using Domain.ValueObjects;
using Inventory.Domain.Abstractions;
using MediatR;

namespace Application.UseCase.Nutritionists.Command.CreateNutritionist
{
    internal class CreateNutritionistHandler : IRequestHandler<CreateNutritionistCommand, Guid>
    {
        private readonly INutritionistFactory _nutritionistFactory;
        private readonly INutritionistRepository _nutritionistRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateNutritionistHandler(
            INutritionistFactory nutritionistFactory,
            INutritionistRepository nutritionistRepository,
            IUnitOfWork unitOfWork)
        {
            _nutritionistFactory = nutritionistFactory;
            _nutritionistRepository = nutritionistRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CreateNutritionistCommand request, CancellationToken cancellationToken)
        {
            // Generar un nuevo ID para el nutricionista
            var nutritionistId = Guid.NewGuid();

            var fullName = new FullName(request.FullName);


            // Crear Nutritionist usando la fábrica
            var nutritionist = _nutritionistFactory.CreateNutritionist(
                nutritionistId,
                fullName,
                request.Specialization,
                NutritionistStatus.Active // Estado inicial predeterminado
            );

            // Guardar en el repositorio
            await _nutritionistRepository.AddAsync(nutritionist);

            // Confirmar transacción
            await _unitOfWork.CommitAsync(cancellationToken);

            // Retornar el ID del nuevo Nutritionist
            return nutritionist.Id;
        }
    }
}
