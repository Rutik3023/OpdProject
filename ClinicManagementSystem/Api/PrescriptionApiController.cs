using AutoMapper;
using ClinicManagementSystem.Iservises;
using ClinicManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClinicManagementSystem.Api
{
    public class PrescriptionApiController : Controller
    {
        // GET: PrescriptionApi
        Iprescripstion c;
        Mapper mp = null;
        public PrescriptionApiController(Iprescripstion _c)
        {
            var config = new MapperConfiguration(u => u.CreateMap<VMPrescription, tblPrescriptionMaster>().ReverseMap());
            mp = new Mapper(config);

            c = _c;

        }

        public  JsonResult Load(int id)
        {
            Reports rp = new Reports();
             var obj =  c.lodCasid(id);
            rp.Code = 0;
            rp.Message = obj;

            return Json(rp, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Loadaid(int id)
        {
            Reports rp = new Reports();
            var obj = c.lodAppoymentid(id);
            rp.Code = 0;
            rp.Message = obj;

            return Json(rp, JsonRequestBehavior.AllowGet);
        }


    }
}