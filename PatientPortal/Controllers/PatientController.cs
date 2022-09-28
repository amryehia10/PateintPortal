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
    [App_Start.Auth]
    public class PatientController : Controller
    {
        // GET: Patient
        public ActionResult Index()
        {
            List<Patientvm> patients = new List<Patientvm>();
            try
            {
                // To open a connection to the database
                using (var context = new PatientDBEntities())
                {
                    // Add data to the particular table
                    patients = context.Patients.ToList();
                    ViewBag.CID = new SelectList(context.Countries.ToList(), "CID", "CName");
                }
            }
            catch (Exception x)
            {

                throw;
            }
            return View(patients);
            return Json(new { data = patients },
                JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetData()
        {
            List<PatientVM> patients = new List<PatientVM>();
            try
            {
                using (var context = new PatientDBEntities())
                {
                    // Add data to the particular table
                    patients = context.Patients.Select(x => new PatientVM()
                    {
                        Addres = x.Addres,
                        CID = x.CID,
                        BirthDate = x.BirthDate,
                        Gender = x.Gender,
                        PID = x.PID,
                        Phone = x.Phone,
                        PName = x.PName,
                        CountryName = x.Country.CName
                    }).ToList();
                    return Json(new { data = patients },
                    JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(new { data = patients },
                JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        //[HttpPost]
        public ActionResult DeletePatient(int Patientid)
        {
            try
            {
                using (var context = new PatientDBEntities())
                {

                    var data = context.Patients.FirstOrDefault(x => x.PID == Patientid);
                    if (data != null)
                    {
                        context.Patients.Remove(data);
                        context.SaveChanges();
                    }

                }
            }
            catch (Exception x)
            {

                throw;
            }
            return RedirectToAction("Index");
            // return Json(new { success = true, message = "Deleted Successfully", JsonRequestBehavior.AllowGet });
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.CID123 = LoadCountries();
            return View();
        }


        List<SelectListItem> LoadCountries()
        {
            using (var context = new PatientDBEntities())
            {
                var countries = context.Countries.ToList();
                List<SelectListItem> lstCountries = new List<SelectListItem>();
                foreach (var item in countries)
                {
                    lstCountries.Add(new SelectListItem { Value = item.CID.ToString(), Text = item.CName });
                }
                return lstCountries;
            }
        }

        [HttpPost]
        public ActionResult Create(Patientvm model)
        {

            // To open a connection to the database
            if (ModelState.IsValid)
            {
                using (var context = new PatientDBEntities())
                {
                    // Add data to the particular table
                    context.Patients.Add(model);

                    // save the changes
                    context.SaveChanges();

                    ViewBag.CID = new SelectList(context.Countries.ToList(), "CID", "CName");
                    //return View();
                    return RedirectToAction("Index");//Json(new { success = true, message = "Saved Successfully", JsonRequestBehavior.AllowGet });

                }
            }
            else
            {
                ViewBag.CID123 = LoadCountries();
                return View();

            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            using (var context = new PatientDBEntities())
            {
                var data = context.Patients.Where(x => x.PID == id).SingleOrDefault();
                if (data == null)
                {
                    return HttpNotFound();
                }
                ViewBag.CID = new SelectList(context.Countries.ToList(), "CID", "CName");
                return View(data);
            }
        }
        [HttpPost]
        public ActionResult Edit(Patientvm Model)
        {
            using (var context = new PatientDBEntities())
            {
                var data = context.Patients.Where(x => x.PID == Model.PID).FirstOrDefault();
                //context.Entry(Model).State = EntityState.Modified;
                if (data != null)
                {
                    data.PName = Model.PName;
                    data.BirthDate = Model.BirthDate;
                    data.Addres = Model.Addres;
                    data.Gender = Model.Gender;
                    data.Phone = Model.Phone;
                    data.CID = Model.CID;
                    context.SaveChanges();
                    ViewBag.CID = new SelectList(context.Countries.ToList(), "CID", "CName");
                }
                //return RedirectToAction("Index");
                return Json(new { success = true, message = "Updated Successfully", JsonRequestBehavior.AllowGet });
            }

        }
    }
}
