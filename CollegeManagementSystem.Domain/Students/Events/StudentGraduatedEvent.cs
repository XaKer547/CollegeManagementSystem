using SharedKernel;

namespace CollegeManagementSystem.Domain.Students.Events;

public sealed class StudentGraduatedEvent : IDomainEvent
{
    public StudentGraduatedEvent(StudentId studentId, bool graduated)
    {
        StudentId = studentId;
        Graduated = graduated;
    }

    public StudentId StudentId { get; set; }
    public bool Graduated { get; set; }
}
