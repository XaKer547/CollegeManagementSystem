using CollegeManagementSystem.Application.Commands.Groups;
using CollegeManagementSystem.Domain.Services;
using FluentValidation;
using MediatR;

namespace CollegeManagementSystem.Application.CommandHandlers.Groups
{
    public sealed class UpdateGroupCommandHandler(IUnitOfWork unitOfWork, IValidator<UpdateGroupCommand> validator) : IRequestHandler<UpdateGroupCommand>
    {
        private readonly IUnitOfWork unitOfWork = unitOfWork;
        private readonly IValidator<UpdateGroupCommand> validator = validator;

        public async Task Handle(UpdateGroupCommand request, CancellationToken cancellationToken)
        {
            await validator.ValidateAndThrowAsync(request, cancellationToken);

            var specialization = unitOfWork.Repository.Specializations.Single(s => s.Id == request.SpecializationId);

            var group = unitOfWork.Repository.Groups.Single(g => g.Id == request.GroupId);

            group.Update(request.Name, specialization);

            unitOfWork.Repository.UpdateEntity(group);

            await unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}