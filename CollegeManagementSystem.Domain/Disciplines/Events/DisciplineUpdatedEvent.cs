using SharedKernel;

namespace CollegeManagementSystem.Domain.Disciplines.Events;

public sealed class DisciplineUpdatedEvent : IDomainEvent
{
    public DisciplineUpdatedEvent(Discipline discipline)
    {
        Discipline = discipline;
    }

    public Discipline Discipline { get; init; }
}
