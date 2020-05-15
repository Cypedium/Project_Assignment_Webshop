using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Assignment_Webshop.Models.Repo.IRepo
{
    public interface IReceiptRepo
    {
        List<Receipt> All();
        Receipt Create(Receipt receipt);
        Receipt Find(int id);
        bool Remove(Receipt receipt);
        Receipt Update(Receipt receipt);
    }
}
