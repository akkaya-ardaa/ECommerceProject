using System;
using Business.Services.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Services.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;

        public ProductManager()
        {
            
        }

        public async Task AddProductAsync(Product product)
        {
            await Task.Delay(4000);
            Console.WriteLine($"Product added successfully. | Title: {product.Title}");
        }

        public async Task DeleteProductAsync(Product product)
        {
            await Task.Delay(4000);
            Console.WriteLine($"Product deleted successfully. | Title: {product.Title}");
        }

        public string GetProducts()
        {
            return "Products retrieved.";
        }

        public async Task UpdateProductAsync(Product product)
        {
            await Task.Delay(4000);
            Console.WriteLine($"Product updated successfully. | Title: {product.Title}");
        }
    }
}

