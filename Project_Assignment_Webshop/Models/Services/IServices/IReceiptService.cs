using Project_Assignment_Webshop.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Assignment_Webshop.Models.IServices
{
    interface IReceiptService
    {
        Receipt Create(ReceiptViewModel receipt);
        Receipt Find(int id);
        Receipt Update(Receipt receipt);
        bool Remove(int id);
        List<Receipt> All();
    }
}
