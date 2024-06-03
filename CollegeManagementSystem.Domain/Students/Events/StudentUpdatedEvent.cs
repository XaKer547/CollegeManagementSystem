using SharedKernel;

namespace CollegeManagementSystem.Domain.Students.Events;

public sealed class StudentUpdatedEvent : IDomainEvent
{
    public StudentUpdatedEvent(Student student)
    {
        Student = student;
    }

    public Student Student { get; init; }
}
