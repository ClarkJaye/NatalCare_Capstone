using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NatalCare.DataAccess.data;

public class PatientRetentionService : BackgroundService
{
    private readonly IServiceProvider _serviceProvider;

    public PatientRetentionService(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            await CheckAndInactivateOldPatients();
            await Task.Delay(TimeSpan.FromHours(24), stoppingToken); // Run every minute
        }
    }

    private async Task CheckAndInactivateOldPatients()
    {
        using (var scope = _serviceProvider.CreateScope())
        {
            var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            var tenYearsAgo = DateTime.Now.AddYears(-10);

            var patientsToInactivate = await context.Patients
                .Where(p =>
                    (p.Updated_At.HasValue && p.Updated_At.Value < tenYearsAgo) ||
                    (!p.Updated_At.HasValue && p.Created_At.HasValue && p.Created_At.Value < tenYearsAgo))
                .ToListAsync();

            foreach (var patient in patientsToInactivate)
            {
                patient.StatusCode = "IN"; // Update the status
                patient.Updated_At = DateTime.Now; // Log the update
            }

            await context.SaveChangesAsync();
        }
    }
}
