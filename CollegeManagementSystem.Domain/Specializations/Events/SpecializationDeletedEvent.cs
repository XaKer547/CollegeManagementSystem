using SharedKernel;

namespace CollegeManagementSystem.Domain.Specializations.Events;

public sealed class SpecializationDeletedEvent : IDomainEvent
{
    public SpecializationDeletedEvent(SpecializationId specializationId)
    {
        SpecializationId = specializationId;
    }

    public SpecializationId SpecializationId { get; init; }
}
