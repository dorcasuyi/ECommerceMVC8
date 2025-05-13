using ECommerceMVC.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECommerceMVC.Repository.IRepository
{
    public interface ICartService
    {
        Task<List<ItemCart>> GetUserCartAsync(int userId);
        Task<bool> AddToCartAsync(ItemCart item);
        Task RemoveFromCartAsync(int cartId);
        //Task UpdateCartItemAsync(ItemCart item);
    }
}
