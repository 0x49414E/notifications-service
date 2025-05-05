using Microsoft.EntityFrameworkCore;
using notificacions_service.Data;

namespace notificacions_service.Repositories
{
	public class UserRepository
	{
		private readonly MockContext _context;

		public UserRepository(MockContext context)
		{
			_context = context;
		}

		public async Task<string> GetConfirmationTokenByUserEmail(string email)
		{
			var user = await _context.users.FirstOrDefaultAsync(u => u.email == email);
			if (user == null)
				throw new NullReferenceException();

			return user.emailConfirmationToken;
		}
	}
}

