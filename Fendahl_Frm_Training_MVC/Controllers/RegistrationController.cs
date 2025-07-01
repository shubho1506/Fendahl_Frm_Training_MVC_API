using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;
using Fendahl_Frm_Training_MVC.DTO;
using Fendahl_Frm_Training_MVC.Models;
using Fendahl_Frm_Training_MVC.Services;
using IRegistrationServices = Fendahl_Frm_Training_MVC.Services.IRegistrationServices;
using RegistrationServices = Fendahl_Frm_Training_MVC.Services.RegistrationServices;

namespace Fendahl_Frm_Training_MVC.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly IRegistrationServices _service;

        public RegistrationController()
        {
            _service = new RegistrationServices();
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View(new REGISTRATION());
        }

        //[HttpPost]
        //public ActionResult Index(REGISTRATION registration)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View(registration);
        //    }

        //    _service.AddAsync(registration);
        //    return RedirectToAction("Dashboard");
        //}

        [HttpPost]
        public ActionResult Index(REGISTRATION registration)
        {
            if (!ModelState.IsValid)
                return View(registration);

            _service.AddAsync(registration);
            Session["UserId"] = registration.ID;
            return RedirectToAction("Dashboard");
        }

        [HttpGet]
        public ActionResult Dashboard()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetData()
        {
            return View(new UpdateDTO());
        }

        //[HttpPost]
        //public ActionResult GetData(UpdateDTO updateDTO)
        //{
        //    var registration = _service.GetByValueAsync(updateDTO);
        //    return RedirectToAction("Details",registration);
        //}

        [HttpPost]
        public ActionResult GetData(UpdateDTO updateDTO)
        {
            var registration = _service.GetByValueAsync(updateDTO);

            if (registration == null)
            {
                ModelState.AddModelError("", "User not found.");
                return View(updateDTO);
            }
            Session["UserId"] = registration.ID;
            return RedirectToAction("Details", new { id = registration.ID });
        }

        //[HttpGet]
        //public ActionResult Details(REGISTRATION person)
        //{
        //    return View(person);
        //}

        [HttpGet]
        public ActionResult Details(int id)
        {
            var person = _service.GetAllAsync().FirstOrDefault(x => x.ID == id);
            if (person == null)
                return HttpNotFound();

            return View(person);
        }

        //[HttpPost]
        //public ActionResult Update(REGISTRATION person)
        //{
        //    _service.UpdateAsync(person);
        //    return RedirectToAction("Success");
        //}

        [HttpPost]
        public ActionResult Update(REGISTRATION person)
        {
            if (!ModelState.IsValid)
                return View(person);

            var success = _service.UpdateAsync(person);
            if (!success)
            {
                ModelState.AddModelError("", "Update failed.");
                return View(person);
            }

            return RedirectToAction("Success");
        }


        [HttpGet]
        public ActionResult Success()
        {
            return View();
        }

        //[HttpGet]
        //public ActionResult DeleteData()
        //{
        //    return View();
        //}

        [HttpGet]
        public ActionResult DeleteData(int id)
        {
            var person = _service.GetAllAsync().FirstOrDefault(x => x.ID == id);
            if (person == null)
                return HttpNotFound();

            return View(person); 
        }


        //[HttpPost]
        //public ActionResult DeleteData(REGISTRATION registration)
        //{
        //    _service.DeleteAsync(registration.ID);
        //    return RedirectToAction("Index");
        //}

        [HttpPost]
        public ActionResult DeleteData(REGISTRATION registration)
        {
            _service.DeleteAsync(registration.ID);
            return RedirectToAction("Index");
        }
    }
}