using System;
using Microsoft.Extensions.Hosting;

namespace Business.Messaging.Abstract
{
	public interface IConsumer : IHostedService
	{
		void ListenForMessages<TEntity>();
	}
}

