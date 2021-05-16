using LBCOnlineShoppingCart.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LBCOnlineShoppingCart.Domain.Interfaces
{
    public interface IAdminRepository
    {
        IEnumerable<Admin> GetAdmin();
        string InsertAdmin(Admin Admin);
        Admin Detail(int? id);
        string UpdateAdmin(Admin Admin);
    }
}
