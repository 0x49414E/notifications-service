using System;
namespace notificacions_service.Models.Configs
{
	public class EmailConfig
	{
        public string? smtpServer { get; set; }
        public int smtpPort { get; set; }
        public string? smtpUsername { get; set; }
        public string? smtpPassword { get; set; }
        public string? fromAddress { get; set; }
    }
}

