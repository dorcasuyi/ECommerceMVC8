using ECommerceMVC.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceMVC.Controllers
{
    public class AuthController : Controller
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {
            var user = await _userService.AuthenticateAsync(email, password);
            if (user == null)
            {
                return View();
            }
            HttpContext.Session.SetInt32("UserId", user.Id);
            return RedirectToAction("Index", "Product");
        }


    }
}
