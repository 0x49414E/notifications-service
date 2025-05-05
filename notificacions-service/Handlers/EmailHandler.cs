using notificacions_service.Interfaces;
using notificacions_service.Interfaces.Services;
using notificacions_service.Models.Emails;
using notificacions_service.Models.Messages;
using notificacions_service.Services;
using notificacions_service.Repositories;
using notificacions_service.Models.Entities;

namespace notificacions_service.Handlers
{
	public class EmailHandler: IHandler
	{
		private readonly SmtpEmailService _smtpEmailService;
		private readonly EmailRepository _emailRepository;

		public EmailHandler(SmtpEmailService smtpEmailService, EmailRepository emailRepository)
		{
			_smtpEmailService = smtpEmailService;
			_emailRepository = emailRepository;
		}

		public async Task<bool> Handle(Message message)
		{
			try
			{
				var email = await _emailRepository.GetEmailByNotificationId(message.notificationId);
				var emailService = GetEmailService(email);
				await emailService.SendNotificationAsync(email);

				return true;
			}
			catch
			{
				return false;
			}
		}

        private IEmailService GetEmailService(Email? email)
		{
			return _smtpEmailService;
		}
	}
}

