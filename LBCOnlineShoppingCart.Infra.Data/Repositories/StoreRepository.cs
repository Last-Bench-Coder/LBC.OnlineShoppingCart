using LBCOnlineShoppingCart.Domain.Interfaces;
using LBCOnlineShoppingCart.Domain.Models;
using LBCOnlineShoppingCart.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LBCOnlineShoppingCart.Infra.Data.Repositories
{
    public class StoreRepository : IStoreRepository
    {
        public LBCShoppingCartContext _context;
        public StoreRepository(LBCShoppingCartContext context)
        {
            _context = context;
        }

        public Store Detail(int? id)
        {
            return _context.Store.Find(id);
        }

        public IEnumerable<Store> GetStore()
        {
            // Add this line
            return _context.Store;
        }

        public string UpdateStatus(Store Store)
        {
            _context.Update(Store);
            _context.SaveChanges();
            return Store.StoreId.ToString();
        }

        public string InsertStore(Store Store)
        {
            _context.Store.Add(Store);
            _context.SaveChanges();
            return Store.StoreId.ToString();
        }
    }
}
