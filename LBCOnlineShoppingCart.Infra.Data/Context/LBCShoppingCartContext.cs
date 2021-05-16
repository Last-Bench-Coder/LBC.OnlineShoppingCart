using LBCOnlineShoppingCart.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LBCOnlineShoppingCart.Infra.Data.Context
{
    public class LBCShoppingCartContext : DbContext
    {
        public LBCShoppingCartContext(DbContextOptions options) : base(options) { }

        public DbSet<Status> Status { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Store> Store { get; set; }
        public DbSet<Admin> Admin { get; set; }
    }
}
