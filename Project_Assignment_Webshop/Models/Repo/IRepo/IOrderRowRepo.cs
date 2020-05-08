using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Assignment_Webshop.Models.Repo.IRepo
{
    public interface IOrderRowRepo
    {
        List<OrderRow> All();
        OrderRow Create(OrderRow orderRow);
        OrderRow Find(int id);
        bool Remove(OrderRow orderRow);
        OrderRow Update(OrderRow orderRow);
    }
}
