using System.ComponentModel.DataAnnotations.Schema;

namespace notificacions_service.Models.Entities
{
    [Table("emails")]
    public class Email
    {
        [Column("email_id")]
        public long id { get; set; }
        [Column("notification_id")]
        public long notificationId { get; set; }
        [Column("email_type")]
        public int emailType { get; set; }
        [Column("to")]
        public string? to { get; set; }
        [Column("cc")]
        public string? cc { get; set; }
        [Column("subject")]
        public string? subject { get; set; }
    }
}

