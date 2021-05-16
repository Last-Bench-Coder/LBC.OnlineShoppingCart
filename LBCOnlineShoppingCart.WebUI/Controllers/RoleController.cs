using LBCOnlineShoppingCart.Application.Interfaces;
using LBCOnlineShoppingCart.Domain.Enums;
using LBCOnlineShoppingCart.Domain.Models;
using LBCOnlineShoppingCart.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LBCOnlineShoppingCart.WebUI.Controllers
{
    public class RoleController : Controller
    {
        private IRoleService _RoleService;
        public RoleController(IRoleService RoleService)
        {
            _RoleService = RoleService;
        }

        #region RoleData
        public IEnumerable<Role> GetAllRole()
        {
            return _RoleService.GetRole();
        }

        public Role GetRoleDetail(int? id)
        {
            return _RoleService.Detail(id);
        }

        public string CreateRole(Role role)
        {
            return _RoleService.InsertRole(role);
        }

        public string UpdateRole(Role role)
        {
            return _RoleService.UpdateRole(role);
        }
        #endregion

        public IActionResult Index()
        {
            if (TempData["SuccessErrorMessage"] != null || TempData["Error"] != null)
            {
                ViewBag.Error = TempData["Error"];
                ViewBag.SuccessErrorMessage = TempData["SuccessErrorMessage"];
            }

            ViewBag.Title = "All Role";
            ViewBag.PageHeading = "All Role";
            ViewBag.PageSmallDesc = "Here is the list of all Role created.";
            IEnumerable<Role> model = GetAllRole();
            return View(model);
        }

        public IActionResult Create()
        {
            ViewBag.Title = "Create Role";
            ViewBag.PageHeading = "Create Role";
            ViewBag.PageSmallDesc = "Here you can create the new Role.";
            return View();
        }

        [HttpPost]
        public IActionResult Create(RoleModel roleModel)
        {
            ViewBag.Title = "Create Role";
            ViewBag.PageHeading = "Create Role";
            ViewBag.PageSmallDesc = "Here you can create the new Role.";

            if (roleModel.IsActive == "0")
                roleModel.IsActive = null;

            if (!ModelState.IsValid)
            {
                return View();
            }
            else
            {
                List<Role> roleList = GetAllRole().ToList();

                if (roleList.Where(m => m.Title == roleModel.Title).FirstOrDefault() != null)
                {
                    ViewBag.Error = "Yes";
                    ViewBag.SuccessErrorMessage = "Opps Save Failed! Role cannot be duplicate. Entered role already exists, Please enter different role title.";
                    return View();
                }
                else
                {
                    try
                    {
                        Role RoleToSubmit = new Role()
                        {
                            Title = roleModel.Title,
                            Description = roleModel.Description,
                            IsActive = Enum.GetName(typeof(eStatus), Convert.ToInt32(roleModel.IsActive)),
                            CreatedUI = "System",
                            DateCreated = DateTime.Now,
                            DateUpdated = DateTime.Now
                        };

                        string Id = CreateRole(RoleToSubmit);

                        TempData["Error"] = "No";
                        TempData["SuccessErrorMessage"] = "Success!!! New Role " + roleModel.Title + " Created Successfully and here is the new Role Id is : " + Id + ".";
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

        public IActionResult Edit(int? id)
        {
            ViewBag.Title = "Edit Role";
            ViewBag.PageHeading = "Edit Role";
            ViewBag.PageSmallDesc = "You can edit or delete the created Role here.";

            Role role = GetRoleDetail(id);

            RoleModel RoleModel = new RoleModel();
            RoleModel.Id = role.Id;
            RoleModel.Title = role.Title;
            RoleModel.Description = role.Description;
            RoleModel.IsActive = ((int)Enum.Parse(typeof(eStatus), role.IsActive)).ToString();//Role.IsActive;

            return View(RoleModel);
        }

        [HttpPost]
        public IActionResult Edit(RoleModel roleModel)
        {
            ViewBag.Title = "Edit Role";
            ViewBag.PageHeading = "Edit Role";
            ViewBag.PageSmallDesc = "You can edit or delete the created Role here.";

            if (roleModel.IsActive == "0")
                roleModel.IsActive = null;

            if (!ModelState.IsValid)
            {
                return View(roleModel);
            }
            else
            {
                List<Role> roleList = GetAllRole().ToList();

                if (roleList.Where(m => m.Title == roleModel.Title && m.Id != roleModel.Id).FirstOrDefault() != null)
                {
                    ViewBag.Error = "Yes";
                    ViewBag.SuccessErrorMessage = "Opps Save Failed! Role cannot be duplicate. Entered role already exists, Please enter different role title.";
                    return View(roleModel);
                }
                else
                {
                    try
                    {
                        Role Role = GetRoleDetail(roleModel.Id);

                        Role.Title = roleModel.Title;
                        Role.Description = roleModel.Description;
                        Role.IsActive = Enum.GetName(typeof(eStatus), Convert.ToInt32(roleModel.IsActive));
                        Role.DateUpdated = DateTime.Now;

                        string result = UpdateRole(Role);

                        TempData["Error"] = "No";
                        TempData["SuccessErrorMessage"] = "Success!!! Role " + roleModel.Title + " updated Successfully.";
                        return RedirectToAction("Index");
                    }
                    catch (Exception ex)
                    {
                        ViewBag.Error = "Yes";
                        ViewBag.SuccessErrorMessage = ex.Message;
                    }
                }
            }
            return View(roleModel);
        }
    }
}
