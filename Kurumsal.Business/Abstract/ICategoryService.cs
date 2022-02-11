using Kurumsal.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kurumsal.Business.Abstract
{
    public interface ICategoryService
    {
        List<Category> GetAll();
    }
}
