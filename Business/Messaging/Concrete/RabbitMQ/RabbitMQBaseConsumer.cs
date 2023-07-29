using System;
using Business.Messaging.Abstract;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Business.Messaging.Concrete.RabbitMQ
{
	public abstract class RabbitMQBaseConsumer : BackgroundService , IConsumer
	{
		public void ListenForMessages<TEntity>()
		{
			var queueName = $"{typeof(TEntity).Name.ToLower()}_operations_queue";
            var factory = new ConnectionFactory
			{
				HostName = "localhost"
			};

			using var connection = factory.CreateConnection();
			using var channel = connection.CreateModel();

			channel.QueueDeclare(queueName, true, false , false);

			var consumer = new EventingBasicConsumer(channel);
			consumer.Received += OnReceived;

			while (true)
			{
                channel.BasicConsume(queueName, true, consumer);
                Thread.Sleep(100);
			}
		}

		public virtual void OnReceived(object? model, BasicDeliverEventArgs ea) =>
			throw new Exception("Please override OnReceived method for inheritances.");
		
	}
}

