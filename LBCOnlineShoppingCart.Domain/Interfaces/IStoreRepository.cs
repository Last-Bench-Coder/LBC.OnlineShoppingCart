using LBCOnlineShoppingCart.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LBCOnlineShoppingCart.Domain.Interfaces
{
    public interface IStoreRepository
    {
        IEnumerable<Store> GetStore();
        string InsertStore(Store Store);
        Store Detail(int? id);
        string UpdateStatus(Store Store);
    }
}
