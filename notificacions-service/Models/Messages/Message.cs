using System;
namespace notificacions_service.Models.Messages
{
	public class Message
	{
        public long notificationId { get; set; }
        public int type { get; set; }
        public int userId { get; set; }
    }
}

