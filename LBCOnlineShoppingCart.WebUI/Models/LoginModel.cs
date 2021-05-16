using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LBCOnlineShoppingCart.WebUI.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage ="EmailId cannot be blank")]
        public string EmailId { get; set; }

        [Required(ErrorMessage = "Password cannot be blank")]
        public string Password { get; set; }
    }
}
