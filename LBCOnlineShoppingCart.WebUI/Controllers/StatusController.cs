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
    public class StatusController : Controller
    {
        private IStatusService _StatusService;
        public StatusController(IStatusService StatusService)
        {
            _StatusService = StatusService;
        }

        #region StatusData
        public IEnumerable<Status> GetAllStatus()
        {
            return _StatusService.GetStatus();
        }

        public Status GetStatusDetail(int? id)
        {
            return _StatusService.Detail(id);
        }

        public string CreateStatus(Status status)
        {
            return _StatusService.InsertStatus(status);
        }

        public string UpdateStatus(Status status)
        {
            return _StatusService.UpdateStatus(status);
        }
        #endregion

        public IActionResult Index()
        {
            if (TempData["SuccessErrorMessage"] != null || TempData["Error"] != null)
            {
                ViewBag.Error = TempData["Error"];
                ViewBag.SuccessErrorMessage = TempData["SuccessErrorMessage"];
            }

            ViewBag.Title = "All Status";
            ViewBag.PageHeading = "All Status";
            ViewBag.PageSmallDesc = "Here is the list of all status created.";
            return View(GetAllStatus());
        }

        public IActionResult Create()
        {
            ViewBag.Title = "Create Status";
            ViewBag.PageHeading = "Create Status";
            ViewBag.PageSmallDesc = "Here you can create the new status.";
            return View();
        }

        [HttpPost]
        public IActionResult Create(StatusModel statusModel)
        {
            ViewBag.Title = "Create Status";
            ViewBag.PageHeading = "Create Status";
            ViewBag.PageSmallDesc = "Here you can create the new status.";

            if (!ModelState.IsValid)
            {
                return View();
            }
            else
            {
                List<Status> statusList = GetAllStatus().ToList();

                if (statusList.Where(m => m.Title == statusModel.Title).FirstOrDefault() != null)
                {
                    ViewBag.Error = "Yes";
                    ViewBag.SuccessErrorMessage = "Opps Save Failed! Status cannot be duplicate. Entered status already exists, Please enter different status title.";
                    return View();
                }
                else
                {
                    try
                    {
                        Status statusToSubmit = new Status()
                        {
                            Title = statusModel.Title,
                            StatusFor = statusModel.StatusFor,
                            Description = statusModel.Description,
                            IsActive = Enum.GetName(typeof(eStatus), Convert.ToInt32(statusModel.IsActive)),
                            CreatedUI = "System",
                            DateCreated = DateTime.Now,
                            DateUpdated = DateTime.Now
                        };

                        string Id = CreateStatus(statusToSubmit);

                        TempData["Error"] = "No";
                        TempData["SuccessErrorMessage"] = "Success!!! New Status " + statusModel.Title + " Created Successfully and here is the new Role Id is : " + Id + ".";
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
            ViewBag.Title = "Edit Status";
            ViewBag.PageHeading = "Edit Status";
            ViewBag.PageSmallDesc = "You can edit or delete the created status here.";

            Status status = GetStatusDetail(id);

            StatusModel statusModel = new StatusModel();
            statusModel.Id = status.Id;
            statusModel.StatusFor = status.StatusFor;
            statusModel.Title = status.Title;
            statusModel.Description = status.Description;
            statusModel.IsActive = ((int)Enum.Parse(typeof(eStatus), status.IsActive)).ToString();

            return View(statusModel);
        }

        [HttpPost]
        public IActionResult Edit(StatusModel statusModel)
        {
            ViewBag.Title = "Edit Status";
            ViewBag.PageHeading = "Edit Status";
            ViewBag.PageSmallDesc = "You can edit or delete the created status here.";

            if (!ModelState.IsValid)
            {
                return View(statusModel);
            }
            else
            {
                List<Status> statusList = GetAllStatus().ToList();

                if (statusList.Where(m => m.Title == statusModel.Title && m.Id != statusModel.Id).FirstOrDefault() != null)
                {
                    ViewBag.Error = "Yes";
                    ViewBag.SuccessErrorMessage = "Opps Save Failed! Status cannot be duplicate. Entered status already exists, Please enter different status title.";
                    return View(statusModel);
                }
                else
                {
                    try
                    {
                        Status status = GetStatusDetail(statusModel.Id);

                        status.StatusFor = statusModel.StatusFor;
                        status.Title = statusModel.Title;
                        status.Description = statusModel.Description;
                        status.IsActive = Enum.GetName(typeof(eStatus), Convert.ToInt32(statusModel.IsActive));
                        status.DateUpdated = DateTime.Now;

                        string statsId = UpdateStatus(status);

                        TempData["Error"] = "No";
                        TempData["SuccessErrorMessage"] = "Success!!! Status " + statusModel.Title + " Updated Successfully.";
                        return RedirectToAction("Index");
                    }
                    catch (Exception ex)
                    {
                        ViewBag.Error = "Yes";
                        ViewBag.SuccessErrorMessage = ex.Message;
                    }
                }
            }
            return View(statusModel);
        }
    }
}
