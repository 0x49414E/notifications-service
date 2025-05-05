using notificacions_service.Consumers;

namespace notificacions_service.Interfaces
{
	public interface IKafkaConsumerFactory
	{
        KafkaConsumer CreateConsumer();
    }
}

