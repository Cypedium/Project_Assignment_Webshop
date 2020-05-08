using Project_Assignment_Webshop.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Assignment_Webshop.Models.IServices
{
    interface IOrderService
    {
        Order Create(OrderViewModel order);
        Order Find(int id);
        Order Update(Order order);
        bool Remove(int id);
        List<Order> All();
    }
}
