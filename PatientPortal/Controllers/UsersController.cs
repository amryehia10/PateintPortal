using PatientPortal.DBContext;
using PatientPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace PatientPortal.Controllers
{
    public class UsersController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Users Model)
        {
            using (var context = new PatientDBEntities())
            {
                var data = context.User.Where(x => x.Email == Model.Email && x.Password == Model.Password).FirstOrDefault();
                if (data != null)
                {
                    //Create session
                    Session["UserData"] = data;
                    return RedirectToAction("Index", "Home");
                    ViewBag.Message = "Logged in Successfully";
                }
                else
                {
                    ViewBag.Message = "Login Failed";
                    return View();
                }

            }
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Register(Users Model)
        {
            if (ModelState.IsValid)
            {
                using (var context = new PatientDBEntities())
                {
                    // Add data to the particular table
                    context.User.Add(Model);

                    // save the changes
                    context.SaveChanges();

                    //return View();
                    return RedirectToAction("Index");

                }
            }
            else
                return View();
        }

        public ActionResult SignOut()
        {
            Session.Abandon();
            return RedirectToAction("Index");
        }

    }
}