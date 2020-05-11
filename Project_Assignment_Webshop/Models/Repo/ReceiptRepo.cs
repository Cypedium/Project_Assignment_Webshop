using Project_Assignment_Webshop.Models.Repo.IRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Assignment_Webshop.Models.Repo
{
    public class ReceiptRepo : IReceiptRepo
    {
        readonly HandleWebshopsDbContext _handleWebshopsDbContext;
        public ReceiptRepo(HandleWebshopsDbContext handleWebshopsDbContext)
        {
            _handleWebshopsDbContext = handleWebshopsDbContext;
        }
        public List<Receipt> All()
        {
            return _handleWebshopsDbContext.Receipts.ToList();
        }

        public Receipt Create(Receipt receipt)
        {
            _handleWebshopsDbContext.Receipts.Add(receipt);

            _handleWebshopsDbContext.SaveChanges();

            return receipt;

        }

        public Receipt Find(int id)
        {
            return _handleWebshopsDbContext.Receipts.SingleOrDefault(receipt => receipt.Id == id);
        }

        public bool Remove(Receipt receipt)
        {
            var result = _handleWebshopsDbContext.Receipts.Remove(receipt);

            _handleWebshopsDbContext.SaveChanges();

            return true;
        }

        public Receipt Update(Receipt receipt)
        {
            Receipt newReceipt = Find(receipt.Id);

            newReceipt.OrderDate = receipt.OrderDate;

            _handleWebshopsDbContext.SaveChanges();

            return newReceipt;
        }
    }
}
