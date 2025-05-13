using ECommerceMVC.Models;

namespace ECommerceMVC.Repository.IRepository
{
    public interface IUserService
    {
        Task<User?> AuthenticateAsync(string email, string password);
    }
}
