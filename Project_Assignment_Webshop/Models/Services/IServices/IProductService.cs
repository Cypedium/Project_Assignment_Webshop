using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Assignment_Webshop.Models
{
    public interface IProductService
    {
        Product Create(ProductViewModel product);
        Product Find(int id);
        Product Update(Product product);
        bool Remove(int id);
        List<Product> All_Current();

        List<Product> All_Out_of_Order();
    }
}
