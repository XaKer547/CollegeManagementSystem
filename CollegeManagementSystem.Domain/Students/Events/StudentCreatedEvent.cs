using SharedKernel;

namespace CollegeManagementSystem.Domain.Students.Events
{
    public sealed class StudentCreatedEvent : IDomainEvent
    {
        public StudentCreatedEvent(Student student)
        {
            Student = student;
        }

        public Student Student { get; set; }
    }
}
