using Cila;
using Cila.Database;
using Confluent.Kafka;
using Microsoft.Extensions.DependencyInjection;

internal class Program
{
    public  static OmniChainAggregatorSettings AppSettings {get;set;}

    private static ServiceProvider _serviceProvider;

    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        var cnfg = new ConfigurationBuilder();
        var configuration = cnfg.AddJsonFile("aggregatorsettings.json")
            .Build();
        AppSettings = configuration.GetSection("AggregatorSettings").Get<OmniChainAggregatorSettings>();

        var configProducer = new ProducerConfig
        {
            BootstrapServers = "localhost:9092",
            ClientId = "dotnet-kafka-producer",
            Acks = Acks.All,
            MessageSendMaxRetries = 10,
            MessageTimeoutMs = 10000,
            EnableIdempotence = true,
            CompressionType = CompressionType.Snappy,
            BatchSize = 16384,
            LingerMs = 10,
            MaxInFlight = 5,
            EnableDeliveryReports = true,
            DeliveryReportFields = "all"
        };
        var configConsumer = new ConsumerConfig
        {
            BootstrapServers = "localhost:9092",
            ClientId = "dotnet-kafka-consumer",
            GroupId = "test-group",
            AutoOffsetReset = AutoOffsetReset.Earliest,
            EnableAutoCommit = false,
            MaxPollIntervalMs = 10000,
            EnablePartitionEof = true,
            SessionTimeoutMs = 6000,
            FetchWaitMaxMs = 1000,
            IsolationLevel = IsolationLevel.ReadCommitted,
            Acks = Acks.All
        };

        var services = new ServiceCollection();

        // Register your dependencies here
        services.AddScoped<IDatabase, MongoDatabase>();
        services.AddScoped<IServiceLocator,ServiceLocator>();
    
        // Build the service provider
        
        services.AddScoped<ServiceProvider>(x=> _serviceProvider);
        _serviceProvider = services.BuildServiceProvider();

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddHostedService<WorkerService>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}