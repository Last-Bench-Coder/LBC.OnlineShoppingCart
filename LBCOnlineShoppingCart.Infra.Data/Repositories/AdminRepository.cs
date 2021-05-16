using LBCOnlineShoppingCart.Domain.Interfaces;
using LBCOnlineShoppingCart.Domain.Models;
using LBCOnlineShoppingCart.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LBCOnlineShoppingCart.Infra.Data.Repositories
{
    public class AdminRepository : IAdminRepository
    {
        public LBCShoppingCartContext _context;
        public AdminRepository(LBCShoppingCartContext context)
        {
            _context = context;
        }

        public string Delete(int? id)
        {
            var Admin = _context.Admin.Find(id);
            if (Admin == null)
            {
                return "0";
            }

            try
            {
                _context.Admin.Remove(Admin);
                _context.SaveChangesAsync();
                return id.ToString();
            }
            catch (DbUpdateException ex)
            {
                return "Error";
            }
        }

        public Admin Detail(int? id)
        {
            return _context.Admin.Find(id);
        }

        public IEnumerable<Admin> GetAdmin()
        {
            // Add this line
            return _context.Admin;
        }

        public string UpdateAdmin(Admin Admin)
        {
            _context.Update(Admin);
            _context.SaveChanges();
            return Admin.AdminId.ToString();
        }

        public string InsertAdmin(Admin Admin)
        {
            _context.Admin.Add(Admin);
            _context.SaveChanges();
            return Admin.AdminId.ToString();
        }
    }
}
