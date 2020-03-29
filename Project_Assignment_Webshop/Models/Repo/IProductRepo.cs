using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Assignment_Webshop.Models
{
    public interface IProductRepo
    {
        Product Create(Product product);
        Product Find(int id);
        Product Update(Product product);
        bool Remove(Product product);
        List<Product> All();   
    }
}
