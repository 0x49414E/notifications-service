using Confluent.Kafka;
using Microsoft.Extensions.Options;
using notificacions_service.Dispatchers;
using notificacions_service.Interfaces;
using notificacions_service.Models.Configs;
using notificacions_service.Models.Messages;

namespace notificacions_service.Consumers
{
	public class KafkaConsumer
	{
        private readonly IConsumer<Ignore, string> _consumer;
        private readonly IDispatcher _dispatcher;

        public KafkaConsumer(IOptions<KafkaConsumerConfig> configuration, MessagesDispatcher messagesDispatcher)
        {
            _dispatcher = messagesDispatcher;
            var config = configuration.Value;
            
			var configConsumer = new ConsumerConfig
            {
                GroupId = config.groupId,
                BootstrapServers = config.bootstrapServers,
                AutoOffsetReset = (AutoOffsetReset?)config.autoOffSetReset
            };
            _consumer = new ConsumerBuilder<Ignore, string>(configConsumer).Build();
            _consumer.Subscribe(config.topics);
        }

        public void Listen()
        {
            while(true)
            {
                var cr = _consumer.Consume();
                var message = System.Text.Json.JsonSerializer.Deserialize<Message>(cr.Message.Value);

               _dispatcher.Process(message);
            }
        }
	}
}

