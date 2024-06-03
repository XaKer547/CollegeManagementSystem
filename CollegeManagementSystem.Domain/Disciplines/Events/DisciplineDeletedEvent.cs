using SharedKernel;

namespace CollegeManagementSystem.Domain.Disciplines.Events;

public sealed class DisciplineDeletedEvent : IDomainEvent
{
    public DisciplineDeletedEvent(DisciplineId disciplineId)
    {
        DisciplineId = disciplineId;
    }

    public DisciplineId DisciplineId { get; init; }
}
