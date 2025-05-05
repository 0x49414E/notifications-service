using notificacions_service.Interfaces.Services;
using notificacions_service.Models.Configs;
using notificacions_service.Models.Entities;
using notificacions_service.Repositories;

namespace notificacions_service.Services
{
	public abstract class EmailService: IEmailService
	{
		public readonly EmailConfig _emailConfig;
		public readonly string? _environment;


		public EmailService(EmailConfig emailConfig, string? enviroment)
		{
			_emailConfig = emailConfig;
			_environment = enviroment;
		}

		public abstract Task SendNotificationAsync(Email message);
		
	}
}

