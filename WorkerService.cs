using Cila;

public class WorkerService : BackgroundService
{
    private const int generalDelay = 1 * 5 * 1000; // 5 seconds
    private readonly IServiceLocator _locator;
    private static AggregatorService _aggregatorService;

    public WorkerService(IServiceLocator locator)
    {
        this._locator = locator;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _aggregatorService = _locator.GetService<AggregatorService>();
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