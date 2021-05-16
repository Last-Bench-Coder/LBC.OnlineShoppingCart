using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LBCOnlineShoppingCart.WebUI.Models
{
    public class AdminModel
    {
        public int AdminId { get; set; }
        public int StoreId { get; set; }
        public string AdminCode { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public string EmailId { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string About { get; set; }
        public string Avatar { get; set; }
        public string LoginId { get; set; }
        public string Password { get; set; }
        [Required]
        public string Role { get; set; }
        [Required]
        public string Status { get; set; }
    }
}