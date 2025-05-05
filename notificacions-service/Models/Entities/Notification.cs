using System.ComponentModel.DataAnnotations.Schema;

namespace notificacions_service.Models.Entities
{
	[Table("notifications")]
	public class Notification
	{
		[Column("notification_id")]
		public long id { get; set; }
		[Column("notification_type_id")]
		public int notificationType { get; set; }
        [Column("user_id")]
        public int user_id { get; set; }
        [Column("created_at")]
        public DateTime created_at { get; set; }
        [Column("state")]
        public int state { get; set; }
	}
}

