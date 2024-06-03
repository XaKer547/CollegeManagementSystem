using CollegeManagementSystem.Application.Commands.Specializations;
using CollegeManagementSystem.Domain.Services;
using CollegeManagementSystem.Domain.Specializations;
using FluentValidation;
using MediatR;

namespace CollegeManagementSystem.Application.CommandHandlers.Specializations
{
    public sealed class CreateSpecializationCommandHandler(IUnitOfWork unitOfWork, IValidator<CreateSpecializationCommand> validator) : IRequestHandler<CreateSpecializationCommand, SpecializationId>
    {
        private readonly IUnitOfWork unitOfWork = unitOfWork;
        private readonly IValidator<CreateSpecializationCommand> validator = validator;

        public async Task<SpecializationId> Handle(CreateSpecializationCommand request, CancellationToken cancellationToken)
        {
            await validator.ValidateAndThrowAsync(request, cancellationToken);

            var specialization = Specialization.Create(request.Name);

            unitOfWork.Repository.AddEntity(specialization);

            await unitOfWork.SaveChangesAsync(cancellationToken);

            return specialization.Id;
        }
    }
}