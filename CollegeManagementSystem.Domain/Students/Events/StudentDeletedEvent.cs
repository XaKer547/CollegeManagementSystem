using SharedKernel;

namespace CollegeManagementSystem.Domain.Students.Events
{
    public sealed class StudentDeletedEvent : IDomainEvent
    {
        public StudentDeletedEvent(StudentId id)
        {
            Id = id;
        }

        public StudentId Id { get; set; }
    }
}
