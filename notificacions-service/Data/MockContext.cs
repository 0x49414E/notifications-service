using Microsoft.EntityFrameworkCore;
using notificacions_service.Models.Entities;

namespace notificacions_service.Data
{
	public class MockContext: DbContext
	{
        public MockContext(DbContextOptions<MockContext> options) : base(options)
        {
        }

        public DbSet<Notification> notifications { get; set; }
        public DbSet<Email> emails { get; set; }
        public DbSet<User> users { get; set; }
    }
}

