using System;
using Entities.Concrete;

namespace Business.Services.Abstract
{
	public interface IProductService
	{
		Task AddProductAsync(Product product);
		Task DeleteProductAsync(Product product);
		Task UpdateProductAsync(Product product);
		string GetProducts();
	}
}

