using Kurumsal.Business.Abstract;
using Kurumsal.Entities.Concrete;
using Kurumsal.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Kurumsal.Web.Controllers
{
    [Authorize(Roles ="Admin")] // sadece adminler görebilir
    public class AdminController : Controller
    {
        private IProductService _productService;
        private ICategoryService _categoryService;

        public AdminController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            var productListViewModel = new ProductListViewModel
            {
                Products = _productService.GetAll()

            };
            return View(productListViewModel);
        }


        public IActionResult Add()
        {
            var model = new ProductAddViewModel
            {
                Product = new Product(),
                Categories = _categoryService.GetAll()

            };
            return View(model);
        }
        [HttpPost]
        public IActionResult Add(Product product)
        {
            if (ModelState.IsValid)
            {
                _productService.Add(product);
                TempData.Add("message", "Product Eklendi.");
            }

            return RedirectToAction("Add");
        }

        public ActionResult Update(int productId)
        {
            var model = new ProductUpdateViewModel
            {
                Product = _productService.GetById(productId),
                Categories = _categoryService.GetAll()
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Update(Product product)
        {
            if (ModelState.IsValid)
            {
                _productService.Update(product);
                TempData.Add("message", "Product Güncellendi.");
            }

            return RedirectToAction("Add");
        }

        public ActionResult Delete(int id)
        {
            _productService.Delete(id);
            TempData.Add("message", "Product Silindi.");
            return RedirectToAction("Index");
        }
    }
}
