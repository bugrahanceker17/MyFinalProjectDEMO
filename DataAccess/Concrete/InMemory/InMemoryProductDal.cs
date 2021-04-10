using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
                new Product{ ProductId=1, CategoryId=1, ProductName="Bardak", UnitPrice=15, UnitsInStock=22 },
                new Product{ ProductId=2, CategoryId=2, ProductName="Kitaplık", UnitPrice=125, UnitsInStock=11 },
                new Product{ ProductId=3, CategoryId=4, ProductName="Basketbol Topu", UnitPrice=60, UnitsInStock=48 },
                new Product{ ProductId=4, CategoryId=4, ProductName="Çatal bıçak seti", UnitPrice=90, UnitsInStock=18 },
                new Product{ ProductId=5, CategoryId=8, ProductName="Ütü Masası", UnitPrice=169, UnitsInStock=8 }
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

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(p => p.CategoryId == categoryId).ToList();
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Product product)
        {
            Product updateToProduct = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            updateToProduct.ProductName = product.ProductName;
            updateToProduct.CategoryId = product.CategoryId;
            updateToProduct.UnitPrice = product.UnitPrice;
            updateToProduct.UnitsInStock = product.UnitsInStock;
        }
    }
}
