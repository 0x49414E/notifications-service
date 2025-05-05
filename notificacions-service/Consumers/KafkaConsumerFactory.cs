using System;
using notificacions_service.Interfaces;

namespace notificacions_service.Consumers
{
	public class KafkaConsumerFactory: IKafkaConsumerFactory
	{
        private readonly IServiceProvider _serviceProvider;

        public KafkaConsumerFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public KafkaConsumer CreateConsumer()
        {
            // Crea un nuevo scope y resuelve la instancia de KafkaConsumer
            var scope = _serviceProvider.CreateScope();
            return scope.ServiceProvider.GetRequiredService<KafkaConsumer>();
        }
    }
}

