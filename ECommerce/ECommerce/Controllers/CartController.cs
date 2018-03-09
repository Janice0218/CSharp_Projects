using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerce.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers
{
    public class CartController : Controller
    {
        private IProductRepository _repository;
        private List<Product> ShoppingCart = new List<Product>();

        public CartController(IProductRepository repository)
        {
            _repository = repository;
        }


        public IActionResult AddToCart(int prodID)
        {
            HttpContext.Session.SetInt32("productID", prodID);

            return RedirectToAction("ViewCart");
        }

        public IActionResult ViewCart()
        {
            var prodID = HttpContext.Session.GetInt32("productID");
            var requestedProduct = _repository.Products.FirstOrDefault(p => p.ProductID == prodID);
            ShoppingCart.Add(requestedProduct);
            return View("ShoppingCart", ShoppingCart);
        }
    }
}
