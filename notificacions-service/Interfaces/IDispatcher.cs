using notificacions_service.Models.Messages;

namespace notificacions_service.Interfaces
{
	public interface IDispatcher
	{
		public Task Process(Message message);
	}
}

