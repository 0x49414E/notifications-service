using notificacions_service.Data;
using notificacions_service.Models.Entities;

namespace notificacions_service.Repositories
{
	public class NotificationRepository
	{
		private readonly MockContext _context;

		public NotificationRepository(MockContext context)
		{
			_context = context;
		}

		public async Task MarkNotificationAsSentAsync(long notificationId)
		{
			var notification = await GetNotification(notificationId);

			if (notification == null)
			{
				return;
			}

			notification.state = 1;
			await _context.SaveChangesAsync();
		}

		private async Task<Notification?> GetNotification(long notification_id)
		{
			return await _context.notifications.FindAsync(notification_id);
		}
	}
}

