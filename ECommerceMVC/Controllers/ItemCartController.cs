using ECommerceMVC.Data;
using ECommerceMVC.Models;
using ECommerceMVC.Repository;
using ECommerceMVC.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;

namespace ECommerceMVC.Controllers
{
    public class ItemCartController : Controller
    {
        private readonly ICartService _cartService;
        private readonly IProductService _productService;
        public ItemCartController(ICartService cartService, IProductService productService)
        {
            _cartService = cartService;
            _productService = productService;
        }
        public async Task<IActionResult> Index()
        {
            var userId = HttpContext.Session.GetInt32("UserId");
        if (userId == null) return RedirectToAction("Login", "Auth");

        var cartItems = await _cartService.GetUserCartAsync(userId.Value);
        return View(cartItems);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] ItemCart item)
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
            {
                return Json(new { success = false, message = "Not logged in" });
            }
                

            item.UserId = userId.Value;
            var result = await _cartService.AddToCartAsync(item);
            return Json(new { success = result });
        }

        public async Task<IActionResult> Add([FromForm] int productId)
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null) return RedirectToAction("Login", "Auth");

            var product = await _productService.GetProductByIdAsync(productId);
            if (product == null) return NotFound();

            var item = new ItemCart
            {
                UserId = userId.Value,
                ProductId = productId,
                Quantity = 1 // Default quantity
            };

            await _cartService.AddToCartAsync(item);
            return RedirectToAction("Index", "Cart");
        }

        //public async Task<IActionResult> Remove(int cartId)
        //{
        //    var userId = HttpContext.Session.GetInt32("UserId");
        //    if (userId == null) return RedirectToAction("Login", "Auth");

        //    await _cartService.RemoveFromCartAsync(cartId);
        //    return RedirectToAction("Index");
        //}
        [HttpDelete("Remove/{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            try
            {
                await _cartService.RemoveFromCartAsync(id);
                return Json(new { success = true });
            }
            catch
            {
                return Json(new { success = false });
            }
        }
    }
}
