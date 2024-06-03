using SharedKernel;

namespace CollegeManagementSystem.Domain.Specializations.Events;

public sealed class SpecializationCreatedEvent : IDomainEvent
{
    public SpecializationCreatedEvent(Specialization specialization)
    {
        Specialization = specialization;
    }

    public Specialization Specialization { get; set; }
}
