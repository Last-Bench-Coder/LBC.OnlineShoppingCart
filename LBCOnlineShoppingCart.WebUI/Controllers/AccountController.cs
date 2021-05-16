using LBCOnlineShoppingCart.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBCOnlineShoppingCart.WebUI.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(LoginModel loginModel)
        {
            if(!ModelState.IsValid)
            {
                return View(loginModel);
            }

            if(loginModel.EmailId=="admin@test.com" && loginModel.Password=="admin")
            {
                return Redirect("home/index");
            }
            else
            {
                ViewBag.SuccessErrorMessage = "Opps Login failed In-valid User Id or Password.";
            }

            return View(loginModel);
        }
    }
}
