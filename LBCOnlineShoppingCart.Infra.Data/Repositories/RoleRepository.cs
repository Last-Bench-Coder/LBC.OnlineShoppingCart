using LBCOnlineShoppingCart.Domain.Interfaces;
using LBCOnlineShoppingCart.Domain.Models;
using LBCOnlineShoppingCart.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LBCOnlineShoppingCart.Infra.Data.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        public LBCShoppingCartContext _context;
        public RoleRepository(LBCShoppingCartContext context)
        {
            _context = context;
        }

        public Role Detail(int? id)
        {
            return _context.Role.Find(id);
        }

        public IEnumerable<Role> GetRole()
        {
            // Add this line
            return _context.Role;
        }

        public string UpdateRole(Role Role)
        {
            _context.Update(Role);
            _context.SaveChanges();
            return Role.Id.ToString();
        }

        public string InsertRole(Role Role)
        {
            _context.Role.Add(Role);
            _context.SaveChanges();
            return Role.Id.ToString();
        }
    }
}
