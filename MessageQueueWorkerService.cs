using Cila;

public class MessageQueueWorkerService : BackgroundService
{
    private KafkaConsumer _consumer;

    public MessageQueueWorkerService(KafkaConsumer consumer)
    {
        this._consumer =  consumer;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        await _consumer.ConsumeAsync("infr", stoppingToken);
    }
}