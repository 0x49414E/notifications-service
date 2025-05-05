using System;
using notificacions_service.Models.Entities;
using notificacions_service.Models.Messages;

namespace notificacions_service.Interfaces.Services
{
	public interface IEmailService
	{
        public Task SendNotificationAsync(Email email);
    }
}

