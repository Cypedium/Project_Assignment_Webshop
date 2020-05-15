using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Assignment_Webshop.Models
{
    public class ProductService : IProductService
    {
        readonly IProductRepo _productRepo;

        public ProductService(IProductRepo productRepo)
        {
            _productRepo = productRepo;
        }
        public List<Product> All_Current()
        {
            return _productRepo.All_Current();
        }

        public List<Product> All_Out_of_Order()
        {
            return _productRepo.All_Out_of_Order();
        }

        public Product Create(ProductViewModel product)
        {
            Product newProduct = new Product()
            {
                ProductType = product.ProductType,
                Number = product.Number,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price
            };
            return _productRepo.Create(newProduct);
           
        }

        public bool Remove(int id)
        {
            Product product = Find(id);
            if (product == null)
            {
                return false;
            }
            return _productRepo.Remove(product);
        }
        public Product Find(int id)
        {
            return _productRepo.Find(id);
        }

        public Product Update(Product product)
        {
            return _productRepo.Update(product); 
        }
    }
}
