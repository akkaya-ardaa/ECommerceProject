using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Messaging.RabbitMQ.Concrete.RabbitMQ;
using Business.Services.Abstract;
using Core.Messaging.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMessageSender _messageSender;

        public ProductsController(IProductService productService, IMessageSender messageSender)
        {
            _productService = productService;
            _messageSender = messageSender;
        }

        [HttpGet("list")]
        public async Task<IActionResult> ListProducts()
        {
            var result = _productService.GetProducts();
            return await Task.FromResult(Ok(result));
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddProduct(Product product)
        {
            _messageSender.SendMessage(new RabbitMQPrompt<Product>()
            {
                Entity = product,
                PromptType = PromptType.Add
            }
            .ToString(), "product_operations_queue");
            return await Task.FromResult(Ok("Added to queue successfully."));
        }

        [HttpPost("delete")]
        public async Task<IActionResult> DeleteProduct(Product product)
        {
            _messageSender.SendMessage(new RabbitMQPrompt<Product>()
            {
                Entity = product,
                PromptType = PromptType.Delete
            }
            .ToString(), "product_operations_queue");
            return await Task.FromResult(Ok("Added to queue successfully."));
        }

        [HttpPost("update")]
        public async Task<IActionResult> UpdateProduct(Product product)
        {
            _messageSender.SendMessage(new RabbitMQPrompt<Product>()
            {
                Entity = product,
                PromptType = PromptType.Update
            }
            .ToString(), "product_operations_queue");
            return await Task.FromResult(Ok("Added to queue successfully."));
        }
    }
}
