using LBCOnlineShoppingCart.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LBCOnlineShoppingCart.Application.Interfaces
{
    public interface IRoleService
    {
        IEnumerable<Role> GetRole();
        string InsertRole(Role RoleViewModel);
        Role Detail(int? id);
        string UpdateRole(Role Role);
    }
}
