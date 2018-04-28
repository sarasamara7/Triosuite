using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Triosuite.Interface;
using Triosuite.Models;

namespace Triosuite.Repositories
{
    public class ProductRepository : IProductRepository
    {
        TSEntities1 ProductDB = new TSEntities1();

        public Product Add(Product item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }

            // TO DO : Code to save record into database
            ProductDB.Products.Add(item);
            ProductDB.SaveChanges();
            return item;
        }

        public bool Delete(int id)
        {
            // TO DO : Code to remove the records from database
            Product products = ProductDB.Products.Find(id);
            ProductDB.Products.Remove(products);
            ProductDB.SaveChanges();
            return true;
        }

        public Product Get(int id)
        {
            // TO DO : Code to find a record in database
            return ProductDB.Products.Find(id);
        }

        public IEnumerable<Product> GetAll()
        {
            // TO DO : Code to get the list of all the records in database
            return ProductDB.Products;
        }

        public bool Update(Product item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }

            // TO DO : Code to update record into database
            var products = ProductDB.Products.Single(a => a.ID == item.ID);
            products.Name = item.Name;
            products.Category = item.Category;
            products.Price = item.Price;
            ProductDB.SaveChanges();

            return true;
        }
        
    }
}