using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kurumsal.Entities.Concrete
{
    public class Cart
    { 
        public List<CartLine> CartLines { get; set; } = new List<CartLine>();
        public decimal Total
        {
            get { return CartLines.Sum(a => a.Product.UnitPrice * a.Quantity); }
        }
    }
}
