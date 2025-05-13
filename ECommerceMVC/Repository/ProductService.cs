using ECommerceMVC.Data;
using ECommerceMVC.Models;
using ECommerceMVC.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;

namespace ECommerceMVC.Repository
{
    public class ProductService : IProductService    
    {
        private readonly ApplicationDbContext _dbContext;

        public ProductService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Product>> GetAllProductsAsync()
        {
             return await _dbContext.Products.ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(int productId)
        {
            return await _dbContext.Products.FirstOrDefaultAsync(p => p.Id == productId);
        }

    }
}
