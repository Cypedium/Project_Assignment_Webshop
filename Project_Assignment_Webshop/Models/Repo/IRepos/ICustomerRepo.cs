using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Assignment_Webshop.Models.Repo.IRepo
{
    public interface ICustomerRepo
    {
        List<Customer> All();
        Customer Create(Customer customer);
        Customer Find(int id);
        bool Remove(Customer customer);
        Customer Update(Customer customer);
    }
}
