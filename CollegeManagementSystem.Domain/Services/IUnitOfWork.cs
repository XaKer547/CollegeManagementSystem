namespace CollegeManagementSystem.Domain.Services;

public interface IUnitOfWork
{
    Task SaveChangesAsync(CancellationToken cancellationToken = default);
    ICollegeManagementSystemRepository Repository { get; }
}
