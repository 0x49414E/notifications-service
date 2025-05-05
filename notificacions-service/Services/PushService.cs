using notificacions_service.Interfaces.Services;
using notificacions_service.Models.Messages;

namespace notificacions_service.Services
{
    public class PushService : IPushService
    {
        public Task SendNotificationAsync(Message message)
        {
            throw new NotImplementedException();
        }
    }
}

