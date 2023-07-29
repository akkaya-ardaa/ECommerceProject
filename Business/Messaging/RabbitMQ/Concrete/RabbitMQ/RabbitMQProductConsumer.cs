using System;
using System.Text;
using Business.Messaging.RabbitMQ.Abstract;
using Business.Services.Abstract;
using Entities.Concrete;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Business.Messaging.RabbitMQ.Concrete.RabbitMQ
{
    public class RabbitMQProductConsumer : RabbitMQBaseConsumer
    {
        private readonly IProductService _productService;
        public RabbitMQProductConsumer(IProductService productService)
        {
            _productService = productService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await Task.Run(ListenForMessages<Product>, stoppingToken);
            Console.WriteLine("Product consumer started for listening.");
        }

        public override void OnReceived(object? model, BasicDeliverEventArgs ea)
        {
            var prompt = JsonConvert.DeserializeObject<RabbitMQPrompt<Product>>(Encoding.UTF8.GetString(ea.Body.ToArray()));

            if(prompt == null)
            {
                throw new Exception("Consumer ile Publisher türleri uyuşmuyor.");
            }

            if(prompt.PromptType == PromptType.Add)
            {
                _productService.AddProductAsync(prompt.Entity);
            }
            else if(prompt.PromptType == PromptType.Update)
            {
                _productService.UpdateProductAsync(prompt.Entity);
            }
            else if(prompt.PromptType == PromptType.Delete)
            {
                _productService.DeleteProductAsync(prompt.Entity);
            }
        }
    }
}

