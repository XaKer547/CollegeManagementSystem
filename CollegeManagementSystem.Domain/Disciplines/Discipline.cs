using CollegeManagementSystem.Domain.Disciplines.Events;
using SharedKernel;

namespace CollegeManagementSystem.Domain.Disciplines;

public sealed class Discipline : Entity<DisciplineId>
{
    private Discipline()
    {
        Id = new DisciplineId();
    }

    public string Name { get; private set; }

    public static Discipline Create(string name)
    {
        var discipline = new Discipline()
        {
            Name = name,
        };

        var disciplineCreatedEvent = new DisciplineCreatedEvent(discipline);

        discipline.AddEvent(disciplineCreatedEvent);

        return discipline;
    }
    public void Delete()
    {
        Deleted = true;

        var disciplineDeletedEvent = new DisciplineDeletedEvent(Id);

        AddEvent(disciplineDeletedEvent);
    }

    public void Update(string name)
    {
        Name = name;

        var disciplineUpdatedEvent = new DisciplineUpdatedEvent(this);

        AddEvent(disciplineUpdatedEvent);
    }
}
