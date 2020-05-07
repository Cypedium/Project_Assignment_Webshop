using Project_Assignment_Webshop.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Assignment_Webshop.Models.Services
{
    public interface ICashierService
    {
        Cashier Create(CashierViewModel cashier); //Create = Save and confirm Orderlist.
        Cashier Find(int id);
        Cashier Update(Cashier cashier);
        bool Remove(int id);
        List<Cashier> All();
    }
}
