using Kurumsal.Entities.Concrete;
using System.Collections.Generic;

namespace Kurumsal.Web.Models
{
    public class CategoryListViewModel
    {
        public List<Category> Categories { get; set; }
        public int CurrentCategory { get; set; }
    }
}
