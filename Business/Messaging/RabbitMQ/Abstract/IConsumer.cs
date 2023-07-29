using System;
using Microsoft.Extensions.Hosting;

namespace Business.Messaging.RabbitMQ.Abstract
{
	public interface IConsumer : IHostedService
	{
		void ListenForMessages<TEntity>();
	}
}

