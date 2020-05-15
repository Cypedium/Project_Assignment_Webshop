using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Assignment_Webshop.Models.Repo.IRepo
{
    public interface IOrderRepo
    {
        List<Order> All();
        Order Create(Order order);
        Order Find(int id);
        bool Remove(Order order);
        Order Update(Order order);
    }
}
