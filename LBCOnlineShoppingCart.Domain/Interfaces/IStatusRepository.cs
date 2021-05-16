using LBCOnlineShoppingCart.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LBCOnlineShoppingCart.Domain.Interfaces
{
    public interface IStatusRepository
    {
        IEnumerable<Status> GetStatus();
        string InsertStatus(Status status);
        Status Detail(int? id);
        string UpdateStatus(Status status);
    }
}
