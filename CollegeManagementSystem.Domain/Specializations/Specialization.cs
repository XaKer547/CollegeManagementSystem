using CollegeManagementSystem.Domain.Specializations.Events;
using SharedKernel;

namespace CollegeManagementSystem.Domain.Specializations;

public sealed class Specialization : Entity<SpecializationId>
{
    private Specialization()
    {
        Id = new SpecializationId();
    }

    public string Name { get; private set; }

    public static Specialization Create(string name)
    {
        var specialization = new Specialization()
        {
            Name = name
        };

        var specializationCreatedEvent = new SpecializationCreatedEvent(specialization);

        specialization.AddEvent(specializationCreatedEvent);

        return specialization;
    }
    public void Update(string name)
    {
        Name = name;

        var specializationUpdatedEvent = new SpecializationUpdatedEvent(this);

        AddEvent(specializationUpdatedEvent);
    }
    public void Delete()
    {
        Deleted = true;

        var specializationDeletedEvent = new SpecializationDeletedEvent(Id);

        AddEvent(specializationDeletedEvent);
    }
}