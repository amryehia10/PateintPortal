using PatientPortal.DBContext;
using PatientPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PatientPortal.Controllers
{
    [App_Start.Auth]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message1 = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Patients()
        {
            List<Patientvm> patients = new List<Patientvm>();
            try
            {
                // To open a connection to the database
                using (var context = new PatientDBEntities())
                {
                    // Add data to the particular table
                    patients = context.Patients.ToList();
                }
            }
            catch (Exception x)
            {

                throw;
            }
            return View(patients);
        }

        public ActionResult Create(Patientvm model)
        {
            // To open a connection to the database
            using (var context = new PatientDBEntities())
            {
                // Add data to the particular table
                context.Patients.Add(model);

                // save the changes
                context.SaveChanges();
            }
            string message = "Created the record successfully";

            // To display the message on the screen
            // after the record is created successfully
            ViewBag.Message = message;

            // write @Viewbag.Message in the created
            // view at the place where you want to
            // display the message
            return View();
        }

    }
}