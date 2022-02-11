using Kurumsal.Entities.Concrete;
using Kurumsal.Web.ExtensionMethods;
using Microsoft.AspNetCore.Http;

namespace Kurumsal.Web.Services
{
    public class CartSessionService : ICartSessionService
    {
        // IHttpContextAccessor'u kullanma sebebimiz; HttpContext.(nokta) 'dan sonra session intellicence'ta çıkmıyor. Çünkü httpcontext controllerlarda çıkar. Burada kullanabilmemiz için IHttpContextAccessor'ü inject ettik.
        private IHttpContextAccessor _httpContextAccessor;
        public CartSessionService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public Cart GetCart()
        {
            // HttpContext.Session intellicense ta geliyor. üstteki açıklamayı oku.
           
            Cart cartToCheck = _httpContextAccessor.HttpContext.Session.GetObject<Cart>("cart"); // sepette ürün var mı kontrolü.
            if (cartToCheck == null)
            {
                _httpContextAccessor.HttpContext.Session.SetObject("cart", new Cart()); // sessionda cart adında sepet nesnesini oluşturduk.
                cartToCheck = _httpContextAccessor.HttpContext.Session.GetObject<Cart>("cart");  
            }
            return cartToCheck;
        }

        public void SetCart(Cart cart)
        {
            _httpContextAccessor.HttpContext.Session.SetObject("cart", cart);
        }
    }
}
