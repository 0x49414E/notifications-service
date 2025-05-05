using System;
using notificacions_service.Handlers;
using notificacions_service.Interfaces;
using notificacions_service.Models.Messages;
using notificacions_service.Repositories;

namespace notificacions_service.Dispatchers
{
	public class MessagesDispatcher: IDispatcher
	{
		private readonly EmailHandler _emailHandler;
		private readonly PushHandler _pushHandler;
		private readonly NotificationRepository _notificationRepository;

		public MessagesDispatcher(EmailHandler emailHandler, PushHandler pushHandler, NotificationRepository notificationRepository)
		{
			_emailHandler = emailHandler;
			_pushHandler = pushHandler;
			_notificationRepository = notificationRepository;
		}

		public async Task Process(Message message)
		{
			var handler = HandlerByTypeMessage(message);
			var result = await handler.Handle(message);

			if (result)
			{
				await _notificationRepository.MarkNotificationAsSentAsync(message.notificationId);
			}
		}

		private IHandler? HandlerByTypeMessage(Message message)
		{
			switch((MessageTypes)message.type)
			{
				case MessageTypes.Email:
					return _emailHandler;

				case MessageTypes.Push:
					return _pushHandler;
			}

			return null;
		}
	}
}

