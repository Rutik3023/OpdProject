using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClinicManagementSystem.Controllers
{
    public class MedicinesController : Controller
    {
        // GET: Medicines
        public ActionResult Index()
        {
            return View();
        }
    }
}