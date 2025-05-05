using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Options;
using notificacions_service.Models.Configs;
using notificacions_service.Models.Emails;
using notificacions_service.Models.Entities;
using notificacions_service.Repositories;

namespace notificacions_service.Services
{
	public class SmtpEmailService: EmailService
	{
        private readonly UserRepository _userRepository;

		public SmtpEmailService(IOptions<EmailConfig> emailConfig, IOptions<EmailTemplatesConfig> environment, UserRepository userRepository)
			:base (emailConfig.Value, environment.Value.emailTemplatesPath)
		{
            _userRepository = userRepository;
		}

        public override async Task SendNotificationAsync(Email email)
        {
            var templateName = await GetTemplateName(email);
            var templateData = await GetTemplateData(email);

            await SendEmailAsync(email.to, email.subject, templateData, templateName);
        }

        private async Task SendEmailAsync(string to, string subject, Dictionary<string, string> templateData, string templateName)
		{
            // Cargar la plantilla
            var templatePath = Path.Combine(_environment, templateName);
            var templateContent = File.ReadAllText(templatePath);

            // Reemplazar keys
            foreach (var key in templateData.Keys)
            {
                templateContent = templateContent.Replace("{{" + key + "}}", templateData[key]);
            }

            // Configurar mensaje
            var mailMessage = new MailMessage
            {
                From = new MailAddress(_emailConfig.fromAddress),
                Subject = subject,
                Body = templateContent,
                IsBodyHtml = true,
            };
            mailMessage.To.Add(to);

            // Configurar cliente SMTP
            using var smtpClient = new SmtpClient(_emailConfig.smtpServer, _emailConfig.smtpPort)
            {
                Credentials = new NetworkCredential(_emailConfig.smtpUsername, _emailConfig.smtpPassword),
                EnableSsl = true,
            };

            // Enviar correo
            await smtpClient.SendMailAsync(mailMessage);
        }

        private async Task<string> GetTemplateName(Email email)
        {
            return EmailTemplateMap.Map[(EmailTypes)email.emailType];
        }

        private async Task<Dictionary<string, string>> GetTemplateData(Email email)
        {
            Dictionary<string, string> templateData;

            switch ((EmailTypes)email.emailType)
            {
                case EmailTypes.UserConfirmation:
                    var confirmationToken = await _userRepository.GetConfirmationTokenByUserEmail(email.to);
                    templateData = new Dictionary<string, string>
                    {
                        { "userName", email.to},
                        { "confirmationToken", confirmationToken}
                    };
                    break;
                default:
                    templateData = new Dictionary<string, string>
                    {
                        { "userName", email.to},
                        { "confirmationToken", ""}
                    };
                    break;
            }

            return templateData;
        }

        private string GetSubject()
        {
            return "Confirmation mail";
        }
	}
}

