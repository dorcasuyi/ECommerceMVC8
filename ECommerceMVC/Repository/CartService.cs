using ECommerceMVC.Data;
using ECommerceMVC.Models;
using ECommerceMVC.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System;

namespace ECommerceMVC.Repository
{
    public class CartService : ICartService
    {
        private readonly ApplicationDbContext _dbContext;

        public CartService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<ItemCart>> GetUserCartAsync(int userId)
        {
            return await _dbContext.ItemCarts.Include(x => x.Product).Where(x => x.UserId == userId).ToListAsync();
        }
            

        public async Task<bool> AddToCartAsync(ItemCart item)
        {
            var existing = await _dbContext.ItemCarts
                .FirstOrDefaultAsync(x => x.ProductId == item.ProductId && x.UserId == item.UserId);

            if (existing != null)
            {
                existing.Quantity += item.Quantity;
            }
            else
            {
                // Fetch product details to include ProductName
                var product = await _dbContext.Products.FindAsync(item.ProductId);
                if (product == null) return false;

                item.ProductName = product.Name;
                await _dbContext.ItemCarts.AddAsync(item);
            }

            var result = await _dbContext.SaveChangesAsync();
            return result > 0;
        }

        public async Task RemoveFromCartAsync(int cartId)
        {
            var item = await _dbContext.ItemCarts.FindAsync(cartId);
            if (item != null)
            {
                _dbContext.ItemCarts.Remove(item);
            }
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateCartItemAsync(ItemCart item)
        {
            //_dbContext.ItemCarts.Update(item);
            //await _dbContext.SaveChangesAsync();

            var existingItem = await _dbContext.ItemCarts.FindAsync(item.Id);
            if (existingItem != null)
            {
                existingItem.Quantity = item.Quantity;
                await _dbContext.SaveChangesAsync();
            }

        }

    }
}
