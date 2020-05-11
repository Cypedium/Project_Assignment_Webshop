using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Assignment_Webshop.Models.Repo.IRepo
{
    public interface ICashierRepo
    {
        List<Cashier> All();
        Cashier Create(Cashier cashier);
        Cashier Find(int id);
        bool Remove(Cashier cashier);
        Cashier Update(Cashier cashier);
    }
}
