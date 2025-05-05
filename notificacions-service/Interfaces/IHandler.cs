using notificacions_service.Models.Messages;

namespace notificacions_service.Interfaces
{
	public interface IHandler
	{
		Task<bool> Handle(Message message);
	}
}

