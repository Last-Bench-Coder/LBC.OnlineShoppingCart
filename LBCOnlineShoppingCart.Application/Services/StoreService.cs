using LBCOnlineShoppingCart.Application.Interfaces;
using LBCOnlineShoppingCart.Domain.Interfaces;
using LBCOnlineShoppingCart.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LBCOnlineShoppingCart.Application.Services
{
    public class StoreService : IStoreService
    {
        public IStoreRepository _StoreRepository;
        public StoreService(IStoreRepository StoreRepository)
        {
            _StoreRepository = StoreRepository;
        }

        public string UpdateStatus(Store Store)
        {
            return _StoreRepository.UpdateStatus(Store);
        }

        public Store Detail(int? id)
        {
            return _StoreRepository.Detail(id);
        }

        public IEnumerable<Store> GetStore()
        {
            //Add this code snippet 
            return _StoreRepository.GetStore();
        }

        public string InsertStore(Store Store)
        {
            return _StoreRepository.InsertStore(Store);
        }
    }
}
