using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LBCOnlineShoppingCart.Domain.Models
{
    public class Store
    {
        [Key]
        public int StoreId { get; set; }
        public string StoreName { get; set; }
        public string Discription { get; set; }
        public string Logo { get; set; }
        public string IsActive { get; set; }
        public string CreatedUI { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }

        public ICollection<Admin> Admin { get; set; }
    }
}
