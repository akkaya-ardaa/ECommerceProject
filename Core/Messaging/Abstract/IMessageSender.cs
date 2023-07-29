using System;
namespace Core.Messaging.Abstract
{
	public interface IMessageSender
	{
		void SendMessage(string body, string queue);
	}
}

