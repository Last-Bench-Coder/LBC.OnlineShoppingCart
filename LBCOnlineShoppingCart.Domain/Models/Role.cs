using System;
using System.Collections.Generic;
using System.Text;

namespace LBCOnlineShoppingCart.Domain.Models
{
    public class Role
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string IsActive { get; set; }
        public string CreatedUI { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
    }
}
