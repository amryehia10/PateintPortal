using PatientPortal.DBContext;
using PatientPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PatientPortal.Controllers
{
    public class CallendarController : Controller
    {
        // GET: Callendar
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetEvents()
        {
            try
            {
                using (PatientDBEntities dc = new PatientDBEntities())
                {
                    var events = dc.Appointments.Select(x => new AppointmentVM()
                    {
                        AppID=x.AppID,
                        Notes = x.Notes,
                        AppFrom = x.AppFrom,
                        AppTo = x.AppTo,
                        Check_in = x.Check_in,
                        PID = x.PID,
                        SID = x.SID,
                        Status = x.Status,
                        ServiceName = x.service.SName,
                        PatientName = x.patient.PName
                    }).ToList();
                    return new JsonResult { Data = events, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                }
            }

            catch (Exception x)
            {
                var tt = x.InnerException.Message;
                return new JsonResult { Data = null, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }

        }

        [HttpPost]
        public JsonResult SaveEvent(AppointmentVM e)
        {
            //Update and Create

            var flag = false;
            try
            {
                using (PatientDBEntities dc = new PatientDBEntities())
                {
                    if (e.AppID > 0)
                    {
                        //Update the event
                        var v = dc.Appointments.FirstOrDefault(a => a.AppID == e.AppID);
                        if (v != null)
                        {
                            v.AppID = e.AppID;
                            v.AppFrom = e.AppFrom;
                            v.AppTo = e.AppTo;
                            v.Check_in = e.Check_in;
                            v.Notes = e.Notes;
                            v.PID = e.PID;
                            v.SID = e.SID;  
                            v.Status = e.Status;
                            v.patient.PName = e.PatientName;  
                            v.service.SName = e.ServiceName;

                            int result = dc.SaveChanges();

                        }

                    }
                    else
                    {
                        Patientvm patient = new Patientvm();
                        Service service = new Service();
                        service.SName = e.ServiceName;
                        patient.PName = e.PatientName;

                        Appointment m = new Appointment();
                        m.AppFrom = e.AppFrom;
                        m.AppTo = e.AppTo;
                        m.Check_in = e.Check_in;
                        m.Notes = e.Notes;
                        //m.PID = e.PID;
                        //m.SID = e.SID;
                        m.Status = e.Status;
                        m.patient = patient;
                        m.service = service;
                        dc.Appointments.Add(m);
                        dc.SaveChanges();
                    }
                    flag = true;
                }
                return new JsonResult { Data = new { status = flag } };
            }
            catch(Exception x)
            {
                var tt = x.InnerException.Message;
                return new JsonResult { Data = null };
            }
        }

        [HttpPost]
        public JsonResult DeleteEvent(int eventID)
        {
            var flag = false;
            try
            {
                using (PatientDBEntities dc = new PatientDBEntities())
                {
                    var v = dc.Appointments.Where(a => a.AppID == eventID).FirstOrDefault();
                    if (v != null)
                    {
                        dc.Appointments.Remove(v);
                        dc.SaveChanges();
                        flag = true;
                    }
                }
                return new JsonResult { Data = new { status = flag } };
            }
            catch(Exception x)
            {
                return new JsonResult { Data = null};
            }
        }
    }
}