using CollegeManagementSystem.Domain.CompanyRepresentatives;
using CollegeManagementSystem.Domain.Disciplines;
using CollegeManagementSystem.Domain.Employees;
using CollegeManagementSystem.Domain.Groups;
using CollegeManagementSystem.Domain.Specializations;
using CollegeManagementSystem.Domain.Students;
using SharedKernel;

namespace CollegeManagementSystem.Domain.Services;

public interface ICollegeManagementSystemRepository
{
    public IQueryable<Group> Groups { get; }
    public IQueryable<Specialization> Specializations { get; }
    public IQueryable<Student> Students { get; }
    public IQueryable<Discipline> Disciplines { get; }
    public IQueryable<Employee> Employees { get; }
    public IQueryable<CompanyRepresentative> CompanyRepresentatives { get; }

    public void AddEntity<TEntity>(TEntity entity) where TEntity : Entity;
    public void UpdateEntity<TEntity>(TEntity entity) where TEntity : Entity;
    public void DeleteEntity<TEntity>(TEntity entity) where TEntity : Entity;
}