using System;
using Microsoft.EntityFrameworkCore;
using notificacions_service.Data;
using notificacions_service.Models.Entities;

namespace notificacions_service.Repositories
{
	public class EmailRepository
	{
		private readonly MockContext _context;

		public EmailRepository(MockContext context)
		{
			_context = context;
		}

		public async Task<Email?> GetEmailByNotificationId(long notificationId)
		{
			return await _context.emails.FirstOrDefaultAsync(e => e.notificationId == notificationId);
		}
	}
}

