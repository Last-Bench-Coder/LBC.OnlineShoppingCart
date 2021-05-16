using LBCOnlineShoppingCart.Application.Interfaces;
using LBCOnlineShoppingCart.Domain.Interfaces;
using LBCOnlineShoppingCart.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LBCOnlineShoppingCart.Application.Services
{
    public class AdminService : IAdminService
    {
        public IAdminRepository _AdminRepository;
        public AdminService(IAdminRepository AdminRepository)
        {
            _AdminRepository = AdminRepository;
        }

        public string UpdateAdmin(Admin Admin)
        {
            return _AdminRepository.UpdateAdmin(Admin);
        }

        public Admin Detail(int? id)
        {
            return _AdminRepository.Detail(id);
        }

        public IEnumerable<Admin> GetAdmin()
        {
            //Add this code snippet 
            return _AdminRepository.GetAdmin();
        }

        public string InsertAdmin(Admin Admin)
        {
            return _AdminRepository.InsertAdmin(Admin);
        }
    }
}
