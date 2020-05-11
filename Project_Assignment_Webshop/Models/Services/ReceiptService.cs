using Project_Assignment_Webshop.Models.Repo.IRepo;
using Project_Assignment_Webshop.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Assignment_Webshop.Models.IServices.InterfaceServices
{
    public class ReceiptService : IReceiptService
    {
        readonly IReceiptRepo _receiptRepo;

        public ReceiptService(IReceiptRepo receiptRepo)
        {
            _receiptRepo = receiptRepo;
        }
        public List<Receipt> All()
        {
            return _receiptRepo.All();
        }

        public Receipt Create(ReceiptViewModel receipt)
        {
            Receipt newReceipt = new Receipt()
            {
                Customer = receipt.Customer,
                OrderDate = receipt.OrderDate,
                OrderRows = receipt.OrderRows
            };
            return _receiptRepo.Create(newReceipt);

        }

        public bool Remove(int id)
        {
            Receipt receipt = Find(id);
            if (receipt == null)
            {
                return false;
            }
            return _receiptRepo.Remove(receipt);
        }
        public Receipt Find(int id)
        {
            return _receiptRepo.Find(id);
        }

        public Receipt Update(Receipt receipt)
        {
            return _receiptRepo.Update(receipt);
        }
    }
}
