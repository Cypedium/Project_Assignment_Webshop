using Project_Assignment_Webshop.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Assignment_Webshop.Models.Services
{
    public interface IOrderRowService
    {
        OrderRow Create(OrderRowViewModel orderRow);
        OrderRow Find(int id);
        OrderRow Update(OrderRow orderRow);
        bool Remove(int id);
        List<OrderRow> All();
    }
}
