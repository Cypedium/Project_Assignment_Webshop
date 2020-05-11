using Project_Assignment_Webshop.Models.Repo.IRepo;
using Project_Assignment_Webshop.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Assignment_Webshop.Models.IServices.InterfaceServices
{
    public class CustomerService : ICustomerService
    {
        readonly ICustomerRepo _customerRepo;

        public CustomerService(ICustomerRepo customerRepo)
        {
            _customerRepo = customerRepo;
        }
        public List<Customer> All()
        {
            return _customerRepo.All();
        }

        public Customer Create(CustomerViewModel customer)
        {
            Customer newCustomer = new Customer()
            {
                F_Name = customer.F_Name,
                L_Name = customer.L_Name,
                E_mail = customer.E_mail,
                UserCreditCard = customer.UserCreditCard
            };
            return _customerRepo.Create(newCustomer);

        }

        public bool Remove(int id)
        {
            Customer costumer = Find(id);
            if (costumer == null)
            {
                return false;
            }
            return _customerRepo.Remove(costumer);
        }
        public Customer Find(int id)
        {
            return _customerRepo.Find(id);
        }

        public Customer Update(Customer customer)
        {
            return _customerRepo.Update(customer);
        }
    }
}
