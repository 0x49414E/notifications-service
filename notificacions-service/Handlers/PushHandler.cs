using notificacions_service.Interfaces;
using notificacions_service.Interfaces.Services;
using notificacions_service.Models.Messages;
using notificacions_service.Services;

namespace notificacions_service.Handlers
{
	public class PushHandler: IHandler
    {
        private readonly IPushService _pushService;

        public PushHandler(IPushService pushService)
        {
            _pushService = pushService;
        }

        public async Task<bool> Handle(Message message)
        {
            return false;
        }
    }
}

