using Project_Assignment_Webshop.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Assignment_Webshop.Models.IServices
{
    public interface ICustomerService
    {
        Customer Create(CustomerViewModel customer);
        Customer Find(int id);
        Customer Update(Customer customer);
        bool Remove(int id);
        List<Customer> All();
    }
}
