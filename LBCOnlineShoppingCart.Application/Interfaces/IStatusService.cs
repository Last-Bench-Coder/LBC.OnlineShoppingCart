using LBCOnlineShoppingCart.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LBCOnlineShoppingCart.Application.Interfaces
{
    public interface IStatusService
    {
        IEnumerable<Status> GetStatus();
        string InsertStatus(Status statusViewModel);
        Status Detail(int? id);
        string UpdateStatus(Status status);
    }
}
