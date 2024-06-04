using CollegeManagementSystem.Infrastucture.Common;
using Microsoft.EntityFrameworkCore;

namespace CollegeManagementSystem.API.HostedServices;

public class DbMigrationWorker(IServiceProvider serviceProvider) : IHostedService
{
    private readonly IServiceProvider serviceProvider = serviceProvider;

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        using (var scope = serviceProvider.CreateScope())
        {
            var context = scope.ServiceProvider.GetRequiredService<CollegeManagementSystemDbContext>();

            var pendingMigration = await context.Database.GetPendingMigrationsAsync(cancellationToken);

            if (pendingMigration.Any())
                await context.Database.MigrateAsync(cancellationToken);
        }
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}