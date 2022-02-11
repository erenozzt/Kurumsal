using Kurumsal.Core.DataAccess;
using Kurumsal.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kurumsal.DataAccess.Abstract
{
    public interface ICategoryDal : IEntityRepository<Category>
    {
    }
}
