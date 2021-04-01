using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{    
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;

        public InMemoryProductDal()
        {
            _products = new List<Product>
            {
                new Product{ ProductId=1, CategoryId=1, ProductName="Bardak", UnitPrice=15, UnitInStock=22 },
                new Product{ ProductId=2, CategoryId=2, ProductName="Kitaplık", UnitPrice=125, UnitInStock=11 },
                new Product{ ProductId=3, CategoryId=4, ProductName="Basketbol Topu", UnitPrice=60, UnitInStock=48 },
                new Product{ ProductId=4, CategoryId=4, ProductName="Çatal bıçak seti", UnitPrice=90, UnitInStock=18 },
                new Product{ ProductId=5, CategoryId=8, ProductName="Ütü Masası", UnitPrice=169, UnitInStock=8 }
            };
        }

        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            Product deleteToProduct = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            _products.Remove(deleteToProduct);
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(p => p.CategoryId == categoryId).ToList();
        }

        public void Update(Product product)
        {
            Product updateToProduct = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            updateToProduct.ProductName = product.ProductName;
            updateToProduct.CategoryId = product.CategoryId;
            updateToProduct.UnitPrice = product.UnitPrice;
            updateToProduct.UnitInStock = product.UnitInStock;
        }
    }
}
