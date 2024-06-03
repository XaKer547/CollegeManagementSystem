using Microsoft.EntityFrameworkCore;
using SmartCollege.SSO.Data;

namespace SmartCollege.SSO.HostedServices
{
    public class ApplyMigrationService : IHostedService
    {
        private readonly IServiceProvider _serviceProvider;

        public ApplyMigrationService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var service = scope.ServiceProvider;
                var dbContext = service.GetRequiredService<AuthorizationDbContext>();

                var pendingMigration = await dbContext.Database.GetPendingMigrationsAsync(cancellationToken);
                if (pendingMigration.Any())
                    await dbContext.Database.MigrateAsync(cancellationToken);
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
