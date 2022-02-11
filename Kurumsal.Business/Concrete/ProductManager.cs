using Kurumsal.Business.Abstract;
using Kurumsal.DataAccess.Abstract;
using Kurumsal.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kurumsal.Business.Concrete
{
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }
        public void Add(Product product)
        {
            _productDal.Add(product);
        }

        public void Delete(int productId)
        {
            _productDal.Delete(new Product { ProductId = productId });
        }


        public List<Product> GetAll()
        {
            return _productDal.GetList();
        }

        public List<Product> GetByCategoryId(int categoryId)
        {
            return _productDal.GetList(p => p.CategoryId == categoryId || categoryId == 0);
        }

        public Product GetById(int productId)
        {
            return _productDal.Get(p=>p.ProductId == productId);
        }

        public void Update(Product product)
        {
            _productDal.Update(product);
        }
    }
}
