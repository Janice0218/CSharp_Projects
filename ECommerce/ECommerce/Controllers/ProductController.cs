using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerce.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace ECommerce.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository _repository;
        public int PageSize = 4;

        public ProductController(IProductRepository repository)
        {
            _repository = repository;
        }

        public IActionResult ProductDirectory(int pageNum = 1)
        {   
            
            return View(_repository.Products.OrderBy(p=>p.ProductID).Skip((pageNum-1)*PageSize).Take(PageSize));
        }


        
    }


}
