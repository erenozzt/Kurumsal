using Kurumsal.Entities.Concrete;
using System.Collections.Generic;

namespace Kurumsal.Web.Models
{
    public class ProductAddViewModel
    {
        public Product  Product { get; set; }
        public List<Category>  Categories { get; set; }
    }
}
