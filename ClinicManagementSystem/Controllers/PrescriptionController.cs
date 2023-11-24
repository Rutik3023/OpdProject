using ClinicManagementSystem.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClinicManagementSystem.Controllers
{
    public class PrescriptionController : Controller
    {   
        // GET: Prescription
        public ActionResult Index()
        {
           ViewBag.Patient=CommonRepo.Patient();
            ViewBag.Medicine = CommonRepo.Medicine();
            return View();
        }
    }
}