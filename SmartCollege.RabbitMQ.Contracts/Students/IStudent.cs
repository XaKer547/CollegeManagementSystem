namespace SmartCollege.RabbitMQ.Contracts.Students;

public interface IStudent
{
    string FirstName { get; }
    string MiddleName { get; }
    string LastName { get; }
}