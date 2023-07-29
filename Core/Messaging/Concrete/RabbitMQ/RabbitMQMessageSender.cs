using System;
using System.Text;
using Core.Messaging.Abstract;
using RabbitMQ.Client;

namespace Core.Messaging.Concrete.RabbitMQ
{
    public class RabbitMQMessageSender : IMessageSender
    {
        private readonly IConnection _connection;
        public RabbitMQMessageSender()
        {
            var factory = new ConnectionFactory
            {
                HostName = "localhost"
            };

            _connection = factory.CreateConnection();
        }

        public void SendMessage(string body, string queue)
        {
            using (var channel = _connection.CreateModel())
            {
                channel.QueueDeclare( //Declare queue if null.
                    queue: queue,
                    durable: true,
                    exclusive: false,
                    autoDelete: false
                );

                var qBody = Encoding.UTF8.GetBytes(body);
                channel.BasicPublish(
                    exchange: "",
                    routingKey: queue, //The queue to send.
                    basicProperties: null,
                    body: qBody
                );
            }
        }
    }

}
