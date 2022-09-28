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
    public class CountryController : Controller
    {
        // GET: Country
        public ActionResult Index()
        {
            List<Country> patients = new List<Country>();
            try
            {
                // To open a connection to the database
                using (var context = new PatientDBEntities())
                {
                    // Add data to the particular table
                    patients = context.Countries.ToList();
                }
            }
            catch (Exception x)
            {

                throw;
            }
            return View(patients);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Country model)
        {
            // To open a connection to the database
            using (var context = new PatientDBEntities())
            {
                // Add data to the particular table
                context.Countries.Add(model);

                // save the changes
                context.SaveChanges();
            }
            return View();
        }

        [HttpGet]
        public ActionResult DeleteCountry(int Countryid)
        {
            try
            {
                using (var context = new PatientDBEntities())
                {

                    var patientsData = context.Patients.FirstOrDefault(x => x.CID == Countryid);
                    if(patientsData == null)
                    {
                        var data = context.Countries.FirstOrDefault(x => x.CID == Countryid);
                        if (data != null)
                        {
                            context.Countries.Remove(data);
                            context.SaveChanges();
                        }
                    }


                }
            }
            catch (Exception x)
            {

                throw;
            }
            return RedirectToAction("Index");
        }
    }
}