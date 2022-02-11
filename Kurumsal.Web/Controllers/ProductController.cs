using Kurumsal.Business.Abstract;
using Kurumsal.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace Kurumsal.Web.Controllers
{
    public class ProductController : Controller
    {
        private IProductService _productService; 
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        public IActionResult Index(int page=1,int categoryId = 0)
        {
            int pageSize = 20;

            var products = _productService.GetByCategoryId(categoryId);
            ProductListViewModel model = new ProductListViewModel
            {
                Products = products.Skip((page-1) * pageSize).Take(pageSize).ToList(),
                PageCount =(int)Math.Ceiling(products.Count/(double)pageSize),
                PageSize = pageSize,
                CurrentCategoryId = categoryId,
                CurrentPage = page,
            };
            return View(model);
        }
         
        //public ActionResult Session()
        //{
        //    // Set lerken
        //    HttpContext.Session.SetString("city", "sakarya");
        //    HttpContext.Session.SetInt32("age", 10);

        //    // okurken
        //    HttpContext.Session.GetString("city");
        //    HttpContext.Session.GetString("age");

        //}
    }
}
