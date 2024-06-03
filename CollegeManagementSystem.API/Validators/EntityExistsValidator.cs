using CollegeManagementSystem.Domain.Users;
using CollegeManagementSystem.Infrastucture.Common;
using FluentValidation;
using SharedKernel;

namespace CollegeManagementSystem.API.Validators;

public abstract class EntityExistsValidator<TEntityId, TEntity> : AbstractValidator<TEntityId>
    where TEntityId : EntityId
    where TEntity : Entity<TEntityId>
{
    public EntityExistsValidator(CollegeManagementSystemDbContext context)
    {
        RuleFor(x => x)
            .NotNull()
            .Must(x => context.Set<TEntity>()
            .Any(e => e.Id == x))
            .WithMessage($"Объект c таким идентификатором не найден или не существует")
            .WithErrorCode("404");
    }
}

public abstract class UserExistsValidator<TEntityId, TEntity> : AbstractValidator<TEntityId>
    where TEntityId : UserId
    where TEntity : User<TEntityId>
{
    public UserExistsValidator(CollegeManagementSystemDbContext context)
    {
        RuleFor(x => x)
            .NotNull()
            .Must(x => context.Set<TEntity>()
            .Any(e => e.Id == x))
            .WithMessage($"Пользователь c таким идентификатором не найден или не существует")
            .WithErrorCode("404");
    }
}