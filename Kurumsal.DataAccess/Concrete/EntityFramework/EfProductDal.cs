using Kurumsal.Core.DataAccess.EntityFramework;
using Kurumsal.DataAccess.Abstract;
using Kurumsal.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kurumsal.DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : EfEntityRepositoryBase<Product,KurumsalContext>,IProductDal
    {
    }
     
}
