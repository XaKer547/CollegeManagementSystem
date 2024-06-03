using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SmartCollege.SSO.Data;

namespace SmartCollege.SSO.HostedServices
{
    public class InizializationRoleBGService : IHostedService
    {
        private readonly IServiceProvider _serviceProvider;

        public InizializationRoleBGService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            using(var scope = _serviceProvider.CreateScope())
            {
                var service = scope.ServiceProvider;
                var dbContext = service.GetRequiredService<RoleManager<IdentityRole>>();

                var roleExists = await dbContext.Roles.AnyAsync(cancellationToken: cancellationToken);
                if (!roleExists)
                {
                    await dbContext.CreateAsync(new IdentityRole(Shared.Roles.Teacher.ToString()));
                    await dbContext.CreateAsync(new IdentityRole(Shared.Roles.Student.ToString()));

                    await dbContext.CreateAsync(new IdentityRole(Shared.Roles.HeadOfDepartment.ToString()));

                    await dbContext.CreateAsync(new IdentityRole(Shared.Roles.ClassroomTeacher.ToString()));

                    await dbContext.CreateAsync(new IdentityRole(Shared.Roles.RepresentativeOfTheCompany.ToString()));
                }
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
