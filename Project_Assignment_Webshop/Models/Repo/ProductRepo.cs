using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Assignment_Webshop.Models
{
    public class ProductRepo : IProductRepo
    {
        readonly HandleWebshopsDbContext _handleWebshopsDbContext;
        public ProductRepo(HandleWebshopsDbContext handleWebshopsDbContext)
        {
            _handleWebshopsDbContext = handleWebshopsDbContext;
        }
        public List<Product> All_Current()
        {
            return _handleWebshopsDbContext.Products.Where(p => p.Out_of_Order == false).ToList();
        }

        public List<Product> All_Out_of_Order()
        {
            return _handleWebshopsDbContext.Products.Where(p => p.Out_of_Order == true).ToList();
        }

        public Product Create(Product product)
        {
            _handleWebshopsDbContext.Products.Add(product);

            _handleWebshopsDbContext.SaveChanges();

            return product;

        }

        public Product Find(int id)
        {
            return _handleWebshopsDbContext.Products.SingleOrDefault(product => product.Id == id);
        }

        public bool Remove(Product product)
        {
            var result = _handleWebshopsDbContext.Products.Remove(product);

            _handleWebshopsDbContext.SaveChanges();

            return true;
        }

        public Product Update(Product product)
        {
            Product newProduct = Find(product.Id);

            newProduct.ProductType = product.ProductType;
            newProduct.Number = product.Number;
            newProduct.Name = product.Name;
            newProduct.Description = product.Description;
            newProduct.Price = product.Price;

            _handleWebshopsDbContext.SaveChanges();

            return newProduct;
        }
    }
}
