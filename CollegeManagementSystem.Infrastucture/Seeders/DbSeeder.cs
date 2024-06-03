using CollegeManagementSystem.Domain.Services;
using CollegeManagementSystem.Infrastucture.Data;

namespace CollegeManagementSystem.Infrastucture.Seeders
{
    public partial class DbSeeder
    {
        private readonly ICollegeManagementSystemRepository _collegeManagementSystemDbContext;

        public DbSeeder(ICollegeManagementSystemRepository collegeManagementSystemDbContext)
        {
            _collegeManagementSystemDbContext = collegeManagementSystemDbContext;
        }

        public async Task Seed()
        {
            await PostSeeder();
        }
    }
}
