using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerce.Infrastructure;
using ECommerce.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers
{
    public class CartController : Controller
    {
        private IProductRepository _repository;
        

        public CartController(IProductRepository repository)
        {
            _repository = repository;
        }


        public IActionResult AddToCart(int prodID)
        {
            var requestedProduct = _repository.Products.FirstOrDefault(p => p.ProductID == prodID);
            Cart cartContents = HttpContext.Session.GetJson<Cart>("Cart") ?? new Cart();
            cartContents.lineItem.Add(requestedProduct);
            HttpContext.Session.SetJson("Cart", cartContents);

            return RedirectToAction("ViewCart");
        }

        public IActionResult ViewCart()
        {
            var cartContents = HttpContext.Session.GetJson<Cart>("Cart");
            
            return View("ShoppingCart", cartContents);
        }
    }
}
