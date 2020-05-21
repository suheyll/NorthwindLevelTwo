using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using Business.Abstract;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using MvcWebUI.Models;

namespace MvcWebUI.ViewComponent
{
    public class CategoryListViewComponent: Microsoft.AspNetCore.Mvc.ViewComponent
    {
        private ICategoryService _categoryService;

        public CategoryListViewComponent(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public ViewViewComponentResult Invoke()
        {
            var model = new CategoryListViewModel()
            {
                Categories = _categoryService.GetAll(),
                CurrentCategory = Convert.ToInt32(HttpContext.Request.Query["category"])
            };

            return View(model);
        }
        
         
    }
}
