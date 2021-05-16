using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LBCOnlineShoppingCart.WebUI.Models
{
    public class StatusModel
    {       
        public int Id { get; set; }

        [Required(ErrorMessage = "Status For Cannot be blank")]
        public string StatusFor { get; set; }

        [Required(ErrorMessage = "Title Cannot be blank")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Description Cannot be blank")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Please select Active or InActive")]
        public string IsActive { get; set; }
    }
}
