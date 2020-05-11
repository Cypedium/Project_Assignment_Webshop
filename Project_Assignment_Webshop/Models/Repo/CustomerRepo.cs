using Project_Assignment_Webshop.Models.Repo.IRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Assignment_Webshop.Models.Repo
{
    public class CustomerRepo : ICustomerRepo
    {
        readonly HandleWebshopsDbContext _handleWebshopsDbContext;
        public CustomerRepo(HandleWebshopsDbContext handleWebshopsDbContext)
        {
            _handleWebshopsDbContext = handleWebshopsDbContext;
        }
        public List<Customer> All()
        {
            return _handleWebshopsDbContext.Customers.ToList();
        }

        public Customer Create(Customer customer)
        {
            _handleWebshopsDbContext.Customers.Add(customer);

            _handleWebshopsDbContext.SaveChanges();

            return customer;

        }

        public Customer Find(int id)
        {
            return _handleWebshopsDbContext.Customers.SingleOrDefault(customer => customer.Id == id);
        }

        public bool Remove(Customer customer)
        {
            var result = _handleWebshopsDbContext.Customers.Remove(customer);

            _handleWebshopsDbContext.SaveChanges();

            return true;
        }

        public Customer Update(Customer customer)
        {
            Customer newCustomer = Find(customer.Id);

            newCustomer.F_Name = customer.F_Name;
            newCustomer.L_Name = customer.L_Name;
            newCustomer.E_mail = customer.E_mail;
            newCustomer.UserCreditCard = customer.UserCreditCard;

            _handleWebshopsDbContext.SaveChanges();

            return newCustomer;
        }
    }
}
