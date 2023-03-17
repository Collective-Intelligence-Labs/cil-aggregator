using Cila;

public class WorkerService : BackgroundService
{
    private const int generalDelay = 1 * 5 * 1000; // 5 seconds
    private static AggregatorService _aggregatorService;

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _aggregatorService = new AggregatorService(Program.AppSettings);
        while (!stoppingToken.IsCancellationRequested)
        {
            await Task.Delay(generalDelay, stoppingToken);
            await PullEvents();
        }
    }

    private static Task PullEvents()
    {
        _aggregatorService.PullNewEvents();
        return Task.FromResult("Done");
    }
}