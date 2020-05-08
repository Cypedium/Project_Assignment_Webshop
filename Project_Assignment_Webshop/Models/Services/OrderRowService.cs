using Project_Assignment_Webshop.Models.IServices;
using Project_Assignment_Webshop.Models.Repo.IRepo;
using Project_Assignment_Webshop.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Assignment_Webshop.Models
{
    public class OrderRowService : IOrderRowService
    {
        readonly IOrderRowRepo _orderRowRepo;

        public OrderRowService(IOrderRowRepo orderRowRepo)
        {
            _orderRowRepo = orderRowRepo;
        }
        public List<OrderRow> All()
        {
            return _orderRowRepo.All();
        }

        public OrderRow Create(OrderRowViewModel orderRow)
        {
            OrderRow newOrderRow = new OrderRow()
            {
                Amount = orderRow.Amount,
                GlutenFree = orderRow.GlutenFree,
                Product = orderRow.Product
                
        };
            return _orderRowRepo.Create(newOrderRow);

        }

        public bool Remove(int id)
        {
            OrderRow orderRow = Find(id);
            if (orderRow == null)
            {
                return false;
            }
            return _orderRowRepo.Remove(orderRow);
        }

        public OrderRow Find(int id)
        {
            return _orderRowRepo.Find(id);
        }

        public OrderRow Update(OrderRow orderRow)
        {
            return _orderRowRepo.Update(orderRow);
        }
    }
}
