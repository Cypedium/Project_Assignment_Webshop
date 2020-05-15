using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Assignment_Webshop.Models
{
    public interface IProductRepo
    {
        List<Product> All_Current();
        List<Product> All_Out_of_Order();
        Product Create(Product product);
        Product Find(int id);
        bool Remove(Product product);
        Product Update(Product product);
    }
}
