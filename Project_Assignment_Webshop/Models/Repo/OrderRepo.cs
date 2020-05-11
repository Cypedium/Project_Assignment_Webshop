using Project_Assignment_Webshop.Models.Repo.IRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Assignment_Webshop.Models.Repo
{
    public class OrderRepo : IOrderRepo
    {
        readonly HandleWebshopsDbContext _handleWebshopsDbContext;
        public OrderRepo(HandleWebshopsDbContext handleWebshopsDbContext)
        {
            _handleWebshopsDbContext = handleWebshopsDbContext;
        }
        public List<Order> All()
        {
            return _handleWebshopsDbContext.Orders.ToList();
        }

        public Order Create(Order order)
        {
            _handleWebshopsDbContext.Orders.Add(order);

            _handleWebshopsDbContext.SaveChanges();

            return order;

        }

        public Order Find(int id)
        {
            return _handleWebshopsDbContext.Orders.SingleOrDefault(order => order.Id == id);
        }

        public bool Remove(Order order)
        {
            var result = _handleWebshopsDbContext.Orders.Remove(order);

            _handleWebshopsDbContext.SaveChanges();

            return true;
        }

        public Order Update(Order order)
        {
            Order newOrder = Find(order.Id);

            newOrder.Customer = order.Customer;
            newOrder.OrderTime = order.OrderTime;
            newOrder.Status = order.Status;
            newOrder.OrderRows = order.OrderRows;

            _handleWebshopsDbContext.SaveChanges();

            return newOrder;
        }
    }
}
