using ClinicManagementSystem.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClinicManagementSystem.Controllers
{
    public class CasePaperController : Controller
    {
        HospitalDBEntities db = new HospitalDBEntities();
        // GET: CasePaper
        public ActionResult Index()
        {
            ViewBag.Patient = CommonRepo.Patient();
            TempData["count"] = db.tblCasePapers.Count();
            return View();
        }
    }
}