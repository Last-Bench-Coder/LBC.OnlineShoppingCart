using LBCOnlineShoppingCart.Domain.Interfaces;
using LBCOnlineShoppingCart.Domain.Models;
using LBCOnlineShoppingCart.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LBCOnlineShoppingCart.Infra.Data.Repositories
{
    public class StatusRepository : IStatusRepository
    {
        public LBCShoppingCartContext _context;
        public StatusRepository(LBCShoppingCartContext context)
        {
            _context = context;
        }

        public Status Detail(int? id)
        {
            return _context.Status.Find(id);
        }

        public IEnumerable<Status> GetStatus()
        {
            // Add this line
            return _context.Status;
        }

        public string UpdateStatus(Status status)
        {
            _context.Update(status);
            _context.SaveChanges();
            return status.Id.ToString();
        }

        public string InsertStatus(Status status)
        {
            _context.Status.Add(status);
            _context.SaveChanges();
            return status.Id.ToString();
        }
    }
}
