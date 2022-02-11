using Kurumsal.Entities.Concrete;
using System.Collections.Generic;

namespace Kurumsal.Web.Models
{
    public class ProductListViewModel
    {
        public List<Product> Products { get; set; }
        public int PageCount { get; set; }
        public int PageSize { get; set; }
        public int CurrentCategoryId { get; set; }
        public int CurrentPage { get; set; }
    }
}
