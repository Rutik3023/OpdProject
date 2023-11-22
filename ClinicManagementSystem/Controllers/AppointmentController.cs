using ClinicManagementSystem.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClinicManagementSystem.Controllers
{
    public class AppointmentController : Controller
    {
        HospitalDBEntities db = new HospitalDBEntities();
        // GET: Appointment
        public ActionResult Index()
        {
            TempData["count"] = db.tblAppointments.Count();
            ViewBag.Dr = CommonRepo.Doctor();
            ViewBag.Patient= CommonRepo.Patient();
            return View();
        }
    }
}