using ECommerceMVC.Models;
using ECommerceMVC.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using ECommerceMVC.Data;
using System;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceMVC.Repository
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _dbContext;

        public UserService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User?> AuthenticateAsync(string email, string password)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == email && u.Password == password);
        }
       

    }
}
