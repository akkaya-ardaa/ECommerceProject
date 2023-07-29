using System;
using Entities.Concrete;
using RabbitMQ.Client.Events;

namespace Business.Messaging.RabbitMQ.Concrete.RabbitMQ
{
    public class RabbitMQCategoryConsumer : RabbitMQBaseConsumer
    {
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await Task.Run(ListenForMessages<Category>, stoppingToken);
        }

        public override void OnReceived(object? model, BasicDeliverEventArgs ea)
        {
            base.OnReceived(model, ea);
        }
    }
}

