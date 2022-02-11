using Kurumsal.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kurumsal.Business.Abstract
{
    public interface IProductService
    {
        List<Product> GetAll();
        List<Product> GetByCategoryId(int categoryId);

        void Add(Product product);
        void Update(Product product);   
        void Delete(int productId);
        Product GetById(int productId); 
    } 

}
