using LBCOnlineShoppingCart.Application.Interfaces;
using LBCOnlineShoppingCart.Domain.Interfaces;
using LBCOnlineShoppingCart.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LBCOnlineShoppingCart.Application.Services
{
    public class RoleService : IRoleService
    {
        public IRoleRepository _RoleRepository;
        public RoleService(IRoleRepository RoleRepository)
        {
            _RoleRepository = RoleRepository;
        }

        public string UpdateRole(Role Role)
        {
            return _RoleRepository.UpdateRole(Role);
        }

        public Role Detail(int? id)
        {
            return _RoleRepository.Detail(id);
        }

        public IEnumerable<Role> GetRole()
        {
            //Add this code snippet 
            return _RoleRepository.GetRole();
        }

        public string InsertRole(Role Role)
        {
            return _RoleRepository.InsertRole(Role);
        }
    }
}
