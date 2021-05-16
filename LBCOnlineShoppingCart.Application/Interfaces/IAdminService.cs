using LBCOnlineShoppingCart.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LBCOnlineShoppingCart.Application.Interfaces
{
    public interface IAdminService
    {
        IEnumerable<Admin> GetAdmin();
        string InsertAdmin(Admin AdminViewModel);
        Admin Detail(int? id);
        string UpdateAdmin(Admin Admin);
    }
}
