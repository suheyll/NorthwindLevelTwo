using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MvcWebUI.Models;

namespace MvcWebUI.Controllers
{
   
    public class ProductController:Controller
    {
        private IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [Authorize]
        public IActionResult index(int category)
        {
            var model = new ProductListViewModel
            {
                Products = category>0?_productService.GetByCategory(category):_productService.GetAll(),
                
            };
            return View(model);
        }
    }
}
