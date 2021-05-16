using LBCOnlineShoppingCart.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LBCOnlineShoppingCart.Domain.Interfaces
{
    public interface IRoleRepository
    {
        IEnumerable<Role> GetRole();
        string InsertRole(Role Role);
        Role Detail(int? id);
        string UpdateRole(Role Role);
    }
}
