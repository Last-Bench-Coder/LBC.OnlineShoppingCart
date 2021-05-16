using LBCOnlineShoppingCart.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LBCOnlineShoppingCart.Application.Interfaces
{
    public interface IStoreService
    {
        IEnumerable<Store> GetStore();
        string InsertStore(Store StoreViewModel);
        Store Detail(int? id);
        string UpdateStatus(Store Store);
    }
}
