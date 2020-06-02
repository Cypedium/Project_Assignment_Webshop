using Project_Assignment_Webshop.Models.Repo.IRepo;
using Project_Assignment_Webshop.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Assignment_Webshop.Models.IServices.InterfaceServices
{
    public class OrderService : IOrderService
    {
        readonly IOrderRepo _orderRepo;

        public OrderService(IOrderRepo orderRepo)
        {
            _orderRepo = orderRepo;
           
        }
        public List<Order> All()
        {
            return _orderRepo.All();
        }

        public Order Create(OrderViewModel order)
        {
            Order newOrder = new Order()
            {
                OrderTime = order.OrderTime,
                Status = order.Status,
                CustomerId = order.CustomerId,
                OrderRows = order.OrderRows
            };
            return _orderRepo.Create(newOrder);

        }

        public bool Remove(int id)
        {
            Order order = Find(id);
            if (order == null)
            {
                return false;
            }
            return _orderRepo.Remove(order);
        }
        public Order Find(int id)
        {
            return _orderRepo.Find(id);
        }

        public Order Update(Order order)
        {
            return _orderRepo.Update(order);
        }
    }
}
