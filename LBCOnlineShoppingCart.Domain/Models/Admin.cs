using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LBCOnlineShoppingCart.Domain.Models
{
    public class Admin
    {
        [Key]
        public int AdminId { get; set; }
        public int StoreId { get; set; }
        public string AdminCode { get; set; }
        public string FullName { get; set; }
        public string EmailId { get; set; }
        public string Phone { get; set; }
        public string About { get; set; }
        public string Avatar { get; set; }
        public string LoginId { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string Status { get; set; }
        public int LoginAttempt { get; set; }
        public string CreatedUI { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }

        public Store Store { get; set; }
    }
}
