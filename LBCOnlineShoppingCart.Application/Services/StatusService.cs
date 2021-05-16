using LBCOnlineShoppingCart.Application.Interfaces;
using LBCOnlineShoppingCart.Domain.Interfaces;
using LBCOnlineShoppingCart.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LBCOnlineShoppingCart.Application.Services
{
    public class StatusService : IStatusService
    {
        public IStatusRepository _StatusRepository;
        public StatusService(IStatusRepository StatusRepository)
        {
            _StatusRepository = StatusRepository;
        }

        public string UpdateStatus(Status status)
        {
            return _StatusRepository.UpdateStatus(status);
        }

        public Status Detail(int? id)
        {
            return _StatusRepository.Detail(id);
        }

        public IEnumerable<Status> GetStatus()
        {
            //Add this code snippet 
            return _StatusRepository.GetStatus();
        }

        public string InsertStatus(Status status)
        {
            return _StatusRepository.InsertStatus(status);
        }
    }
}
