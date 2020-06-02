using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Assignment_Webshop.Models.Repo.IRepo
{
    public class OrderRowRepo : IOrderRowRepo
    {
        readonly HandleWebshopsDbContext _handleWebshopsDbContext;

        public OrderRowRepo(HandleWebshopsDbContext handleWebshopsDbContext)
        {
            _handleWebshopsDbContext = handleWebshopsDbContext;
        }

        public List<OrderRow> All()
        {
            return _handleWebshopsDbContext.OrderRows.ToList();
        }

        public OrderRow Create(OrderRow orderRow)
        {
            _handleWebshopsDbContext.OrderRows.Add(orderRow);

            _handleWebshopsDbContext.SaveChanges();

            return orderRow;

        }

        public OrderRow Find(int id)
        {
            return _handleWebshopsDbContext.OrderRows.SingleOrDefault(orderRow => orderRow.Id == id);
        }

        public bool Remove(OrderRow orderRow)
        {
            var result = _handleWebshopsDbContext.OrderRows.Remove(orderRow);

            _handleWebshopsDbContext.SaveChanges();

            return true;
        }

        public OrderRow Update(OrderRow orderRow)
        {
            OrderRow newOrderRow = Find(orderRow.Id);

            newOrderRow.Product = orderRow.Product;
            newOrderRow.Price = orderRow.Price;
            newOrderRow.GlutenFree = orderRow.GlutenFree;

            _handleWebshopsDbContext.SaveChanges();

            return newOrderRow;
        }
    }
}
