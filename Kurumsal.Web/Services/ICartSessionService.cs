using Kurumsal.Entities.Concrete;

namespace Kurumsal.Web.Services
{
    public interface ICartSessionService
    {
        Cart GetCart();
        void SetCart(Cart cart);
    }
}
