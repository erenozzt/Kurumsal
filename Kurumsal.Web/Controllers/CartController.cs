using Kurumsal.Business.Abstract;
using Kurumsal.Entities.Concrete;
using Kurumsal.Web.Models;
using Kurumsal.Web.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Kurumsal.Web.Controllers
{
    public class CartController : Controller
    {

        private ICartSessionService _cartSessionService;

        private ICartService _cartService;
        private IProductService _productService;
        public CartController(ICartSessionService cartSessionService, ICartService cartService,IProductService productService)
        {
            _cartSessionService = cartSessionService;
            _cartService = cartService;
            _productService = productService;
        }
            
        public IActionResult AddToCart(int productId)
        {
            var productToBeAdded = _productService.GetById(productId);

            var cart = _cartSessionService.GetCart();
            _cartService.AddToCart(cart,productToBeAdded);
            _cartSessionService.SetCart(cart);

            TempData.Add("message", string.Format("your product  {0} was succesfully added to the cart!",productToBeAdded.ProductName));

            return RedirectToAction("Index","Product");
        }

        public IActionResult List()
        { 

            var cart = _cartSessionService.GetCart();
            CartSummaryViewModel model = new CartSummaryViewModel
            {
                Cart=cart
            };
             
            return View(model);
        }

        public IActionResult Remove(int productId)
        {

            var cart = _cartSessionService.GetCart();
            _cartService.RemoveFromCart(cart, productId);
            _cartSessionService.SetCart(cart);

            TempData.Add("message", string.Format("your product was succesfully removed from the cart!"));
            return RedirectToAction("List");
          
        }

        public IActionResult Complete()
        {
            var shippingDetailsViewModel = new ShippingDetailsViewModel
            {
                ShippingDetails = new ShippingDetails(),
            };

            return View(shippingDetailsViewModel);
        }

        [HttpPost]
        public IActionResult Complete(ShippingDetails shippingDetails)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            TempData["message"] = String.Format("thanks {0}", shippingDetails.FirstName);
            return View();
        }
    }
}
