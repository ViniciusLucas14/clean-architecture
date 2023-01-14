using System;
using CleanArchMVC.Domain.Entities;

namespace CleanArchMVC.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> CreateAsync(Product product);
        Task<Product> UpdateAsync(Product product);
        Task<Product> RemoveAsync(Product product);
        Task<Product> GetByIdAsync(int? id);
        Task<Product> GetProductCategoryAsync(int? id);
        Task<IEnumerable<Product>> GetProductsAsync();
    }
}