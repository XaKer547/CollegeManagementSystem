using SmartCollege.RabbitMQ.Contracts.Students;

namespace SmartCollege.RabbitMQ.Contracts.Groups;

public interface IGroupGraduated
{
    string Name { get; }
    IStudent[] Student { get; }
    string Specialization { get; }
}