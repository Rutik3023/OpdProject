using Rotativa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClinicManagementSystem.Controllers
{
    public class PrintController : Controller
    {
        // GET: Print
        public ActionResult PrintData()
        {
            var pdf = new ViewAsPdf("PrintData"); // StaticPage is the name of your HTML view
            return pdf;
        }
    }
}