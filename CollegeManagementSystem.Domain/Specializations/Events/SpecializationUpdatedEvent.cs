using SharedKernel;

namespace CollegeManagementSystem.Domain.Specializations.Events;

public sealed class SpecializationUpdatedEvent : IDomainEvent
{
    public SpecializationUpdatedEvent(Specialization specialization)
    {
        Specialization = specialization;
    }

    public Specialization Specialization { get; init; }
}
