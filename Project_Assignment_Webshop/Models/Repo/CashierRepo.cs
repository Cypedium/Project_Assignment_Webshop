using Project_Assignment_Webshop.Models.Repo.IRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Assignment_Webshop.Models.Repo
{
    public class CashierRepo : ICashierRepo
    {
        readonly HandleWebshopsDbContext _handleWebshopsDbContext;
        public CashierRepo(HandleWebshopsDbContext handleWebshopsDbContext)
        {
            _handleWebshopsDbContext = handleWebshopsDbContext;
        }
        public List<Cashier> All()
        {
            return _handleWebshopsDbContext.Cashiers.ToList();
        }

        public Cashier Create(Cashier cashier)
        {
            _handleWebshopsDbContext.Cashiers.Add(cashier);

            _handleWebshopsDbContext.SaveChanges();

            return cashier;

        }

        public Cashier Find(int id)
        {
            return _handleWebshopsDbContext.Cashiers.SingleOrDefault(cashier => cashier.Id == id);
        }

        public bool Remove(Cashier cashier)
        {
            var result = _handleWebshopsDbContext.Cashiers.Remove(cashier);

            _handleWebshopsDbContext.SaveChanges();

            return true;
        }

        public Cashier Update(Cashier cashier)
        {
            Cashier newCashier = Find(cashier.Id);

            newCashier.Customer = cashier.Customer;

            newCashier.Customer = cashier.OrderTime;

            _handleWebshopsDbContext.SaveChanges();

            return newCashier;
        }
    }
}
