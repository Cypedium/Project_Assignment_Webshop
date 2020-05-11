using Project_Assignment_Webshop.Models.Repo.IRepo;
using Project_Assignment_Webshop.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Assignment_Webshop.Models.IServices
{
    public class CashierService : ICashierService
    {
        readonly ICashierRepo _cashierRepo;

        public CashierService(ICashierRepo cashierRepo)
        {
            _cashierRepo = cashierRepo;
        }
        public List<Cashier> All()
        {
            return _cashierRepo.All();
        }

        public Cashier Create(CashierViewModel cashier)
        {
            Cashier newCashier = new Cashier()
            {
                Customer = cashier.Costumer,
                OrderTime = cashier.OrderTime,
                OrderRows = cashier.OrderRows   
            };
            return _cashierRepo.Create(newCashier);

        }

        public bool Remove(int id)
        {
            Cashier cashier = Find(id);
            if (cashier == null)
            {
                return false;
            }
            return _cashierRepo.Remove(cashier);
        }
        public Cashier Find(int id)
        {
            return _cashierRepo.Find(id);
        }

        public Cashier Update(Cashier cashier)
        {
            return _cashierRepo.Update(cashier);
        }
    }
}
