using System;
namespace notificacions_service.Models.Configs
{
	public class KafkaConsumerConfig
	{
		public string? bootstrapServers { get; set; }
		public string? groupId { get; set; }
		public int autoOffSetReset { get; set; }
		public List<string>? topics { get; set; }
	}
}

