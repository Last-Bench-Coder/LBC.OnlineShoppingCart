using LBCOnlineShoppingCart.Application.Interfaces;
using LBCOnlineShoppingCart.Domain.Enums;
using LBCOnlineShoppingCart.Domain.Models;
using LBCOnlineShoppingCart.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBCOnlineShoppingCart.WebUI.Controllers
{
    public class AdminController : Controller
    {
        private IAdminService _AdminService;
        private IRoleService _RoleService;
        private IStatusService _StatusService;
        private IStoreService _StoreService;
        public AdminController(IAdminService AdminService, IRoleService RoleService, 
            IStatusService StatusService, IStoreService StoreService)
        {
            _AdminService = AdminService;
            _RoleService = RoleService;
            _StatusService = StatusService;
            _StoreService = StoreService;
        }

        #region AdminData
        public IEnumerable<Role> GetAllRole()
        {
            return _RoleService.GetRole();
        }

        public IEnumerable<Status> GetAllStatus()
        {
            return _StatusService.GetStatus();
        }

        public IEnumerable<Store> GetAllStore()
        {
            return _StoreService.GetStore();
        }

        public IEnumerable<Admin> GetAllAdmin()
        {
            return _AdminService.GetAdmin();
        }

        public Admin GetAdminDetail(int? id)
        {
            return _AdminService.Detail(id);
        }

        public string CreateAdmin(Admin admin)
        {
            return _AdminService.InsertAdmin(admin);
        }

        public string UpdateAdmin(Admin admin)
        {
            return _AdminService.UpdateAdmin(admin);
        }
        #endregion

        public IActionResult Index()
        {
            if (TempData["SuccessErrorMessage"] != null || TempData["Error"] != null)
            {
                ViewBag.Error = TempData["Error"];
                ViewBag.SuccessErrorMessage = TempData["SuccessErrorMessage"];
            }

            ViewBag.Title = "All Admin";
            ViewBag.PageHeading = "All Admin";
            ViewBag.PageSmallDesc = "Here is the list of all Admin created.";
            IEnumerable<Admin> model = GetAllAdmin();
            return View(model);
        }

        public IActionResult Create()
        {
            List<Admin> adminList = GetAllAdmin().ToList();
            int adminId = adminList.Max(m => m.AdminId);

            List<Role> roleList = GetAllRole().ToList();
            List<Status> statusList = GetAllStatus().ToList();
            List<Store> storeList = GetAllStore().ToList();
            ViewBag.Role = roleList;
            ViewBag.Status = statusList;
            ViewBag.Store = storeList;

            AdminModel adminModel = new AdminModel();
            adminModel.AdminCode = "ADMLBC101" + (adminId + 1);

            return View(adminModel);
        }

        [HttpPost]
        public IActionResult Create(AdminModel adminModel)
        {
            ViewBag.Title = "Create Admin";
            ViewBag.PageHeading = "Create Admin";
            ViewBag.PageSmallDesc = "Here you can create the new Admin.";

            List<Role> roleList = GetAllRole().ToList();
            List<Status> statusList = GetAllStatus().ToList();
            List<Store> storeList = GetAllStore().ToList();
            ViewBag.Role = roleList;
            ViewBag.Status = statusList;
            ViewBag.Store = storeList;

            if (!ModelState.IsValid)
            {
                return View(adminModel);
            }
            else
            {
                List<Admin> adminList = GetAllAdmin().ToList();

                if (adminList.Where(m => m.EmailId == adminModel.EmailId || m.Phone == adminModel.Phone).FirstOrDefault() != null)
                {
                    ViewBag.Error = "Yes";
                    ViewBag.SuccessErrorMessage = "Opps Save Failed! Admin email or phone cannot be duplicate. Entered admin already exists, Please enter different admin title.";
                    return View();
                }
                else
                {
                    try
                    {
                       
                        Admin AdminToSubmit = new Admin()
                        {
                            StoreId = adminModel.StoreId,
                            AdminCode = adminModel.AdminCode,
                            FullName = adminModel.FullName,
                            EmailId = adminModel.EmailId,
                            Phone = adminModel.Phone,
                            About = adminModel.About,
                            Avatar = adminModel.Avatar,
                            LoginId = adminModel.EmailId.Substring(0, adminModel.EmailId.IndexOf('@')),
                            Password = "admin",
                            Role = Enum.GetName(typeof(eRole), Convert.ToInt32(adminModel.Role)),
                            Status = Enum.GetName(typeof(eAdminStatus), Convert.ToInt32(adminModel.Status)),
                            LoginAttempt = 0,
                            CreatedUI = "System",
                            DateCreated = DateTime.Now,
                            DateUpdated = DateTime.Now
                        };

                        string Id = CreateAdmin(AdminToSubmit);

                        TempData["Error"] = "No";
                        TempData["SuccessErrorMessage"] = "Success!!! New Admin " + adminModel.FullName + " Created Successfully and here is the new Admin Id is : " + Id + ".";
                        return RedirectToAction("Index");
                    }
                    catch (Exception ex)
                    {
                        ViewBag.Error = "Yes";
                        ViewBag.SuccessErrorMessage = ex.Message;
                    }
                }
            }
            return View();
        }
    }
}
