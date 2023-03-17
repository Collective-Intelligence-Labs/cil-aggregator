public class WorkerService : BackgroundService
{
    private const int generalDelay = 1 * 5 * 1000; // 5 seconds
        
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            await Task.Delay(generalDelay, stoppingToken);
            await PullEvents();
        }
    }

    private static Task PullEvents()
    {
        
        return Task.FromResult("Done");
    }
}