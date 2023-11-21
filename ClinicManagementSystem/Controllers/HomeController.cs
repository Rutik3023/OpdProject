using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClinicManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        HospitalDBEntities db = new HospitalDBEntities();
        // GET: Home
        [Authorize]
        public ActionResult Index()
        {
           ViewBag.patient =  db.tblPatients.Count();
            ViewBag.Doctor = db.tblDoctors.Count();
            ViewBag.Appoyment = db.tblAppointments.Count();
            ViewBag.Staff = db.tblStaffs.Count();
            return View();
        }
    }
}