using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Fendahl_Frm_Training_MVC.Models;
using Fendahl_Frm_Training_MVC.Services;

namespace Fendahl_Frm_Training_MVC.Controllers
{
    public class FeedbackController : Controller
    {
        private readonly IFeedbackServices _service;

        public FeedbackController()
        {
            _service = new FeedbackServices();
        }


        [HttpGet]
        public ActionResult Create()
        {
            return View(new FEEDBACK());
        }

        //[HttpPost]
        //public ActionResult Create(FEEDBACK feedback)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View(feedback);
        //    }

        //    _service.AddFeedBack(feedback);
        //    return RedirectToAction("Success");
        //}

        [HttpPost]
        public ActionResult Create(FEEDBACK feedback)
        {
            if (!ModelState.IsValid)
            {
                return View(feedback);
            }
            if (Session["UserId"] != null)
            {
                feedback.USER_ID = Convert.ToInt32(Session["UserId"]);
            }
            else
            {
                ModelState.AddModelError("", "Session expired. Please login again.");
                return View(feedback);
            }

            _service.AddFeedBack(feedback);
            return RedirectToAction("Success");
        }


        [HttpGet]
        public ActionResult Success()
        {
            return View();
        }
    }
}