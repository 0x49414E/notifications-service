using Confluent.Kafka;
using notificacions_service.Consumers;
using notificacions_service.Interfaces;
using notificacions_service.Models.Messages;
using static Confluent.Kafka.ConfigPropertyNames;

namespace notificacions_service;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    //private readonly string bootstrapServers = "localhost:9092";
    //private readonly string topic = "topic-user-created";
    //private readonly IKafkaConsumerFactory _kafkaConsumerFactory;
    private readonly IServiceScopeFactory _scopeFactory;

    public Worker(ILogger<Worker> logger, IServiceScopeFactory scopeFactory)
    {
        _logger = logger;
        //_kafkaConsumerFactory = kafkaConsumerFactory;//new KafkaConsumer();
        _scopeFactory = scopeFactory;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        //while (!stoppingToken.IsCancellationRequested)
        //{
        //    _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
        //    await Task.Delay(1000, stoppingToken);
        //}
        //var config = new ConsumerConfig
        //{
        //    GroupId = "notification-group",
        //    BootstrapServers = bootstrapServers,
        //    AutoOffsetReset = AutoOffsetReset.Earliest
        //};
        //using var consumer = new ConsumerBuilder<Ignore, string>(config).Build();
        //consumer.Subscribe(topic);
        //try
        //{
        //    while (!stoppingToken.IsCancellationRequested)
        //    {
        //        var consumeResult = consumer.Consume(stoppingToken);
        //        var user = System.Text.Json.JsonSerializer.Deserialize<Message>(consumeResult.Message.Value);
        //        _logger.LogInformation($"Recibido evento de usuario creado: {user.email}");
        //        // Aquí se podría enviar la notificación por email.
        //    }
        //}
        //catch (OperationCanceledException)
        //{
        //    consumer.Close();
        //}

        //stoppingToken.ThrowIfCancellationRequested();
        //var kafkaConsumer = _kafkaConsumerFactory.CreateConsumer();
        //await Task.Run(() => kafkaConsumer.Listen(), stoppingToken);

        stoppingToken.ThrowIfCancellationRequested();
        using (var scope = _scopeFactory.CreateScope())
        {
            var kafkaConsumerFactory = scope.ServiceProvider.GetRequiredService<IKafkaConsumerFactory>();
            var kafkaConsumer = kafkaConsumerFactory.CreateConsumer();
            await Task.Run(() => kafkaConsumer.Listen(), stoppingToken);
        }
    }
}

