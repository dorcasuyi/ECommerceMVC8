using ECommerceMVC.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ECommerceMVC.Repository.IRepository
{
    public interface IProductService
    {
       Task<List<Product>> GetAllProductsAsync(); 
       Task<Product> GetProductByIdAsync(int productId);
    }
}
