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
    public class AppointmentApiController : Controller
    {
        // GET: AppointmentApi
        IAppointment c;
        Mapper mp = null;
        public AppointmentApiController(IAppointment _c)
        {
            var config = new MapperConfiguration(u => u.CreateMap<VMAppointment, tblAppointment>().ReverseMap());
            mp = new Mapper(config);

            c = _c;

        }


        // GET: Api


        public JsonResult GetAllC(int pagno)
        {
            Reports rp = new Reports();

            var obj = c.GetAll();
            var objt = c.GetAllPage(pagno);

            //List<VMAppointment> list = mp.Map<List<VMAppointment>>(objt);




            rp.pageno = pagno;
            rp.count = obj.Count();
            rp.Code = 0;
            rp.Message = objt;

            return Json(rp, JsonRequestBehavior.AllowGet);
        }


        public JsonResult FindByid(int id)
        {
            Reports rp = new Reports();

            var obj = c.FindById(id);
            VMAppointment list = mp.Map<VMAppointment>(obj);

            rp.Code =0;
            rp.Message = obj;
            return Json(rp, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Save(VMAppointment obj)
        {
            Reports rp = new Reports();
            
            tblAppointment list = mp.Map<tblAppointment>(obj);
            var res = c.Save(list);



            rp.Code = 0;
            rp.Message = res;
            //if (ModelState.IsValid)
            //{







            //}
            //else
            //{
            //    rp.Code = -1;
            //    rp.Message = CommonRepo.GetAdditionValidaitonIssues(ModelState);
            //}






            return Json(rp, JsonRequestBehavior.AllowGet);
        }

      public JsonResult Delete(int id)
        {
            Reports rp = new Reports();
            var obj = c.Delete(id);
            if (obj == true)
            {
                rp.Code = 0;
                rp.Message = "Deleted  Successfully";
            }



            return Json(rp, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetAll(string key)
        {
            Reports rp = new Reports();

            var obj = c.GetAllKey(key);

            if (obj != null)
            {
                rp.Code = 0;
                rp.Message = obj;
            }

            return Json(rp, JsonRequestBehavior.AllowGet);

        }

        public JsonResult Loadcasid(int id)
        {
            Reports rp = new Reports();

            var obj = c.loadCasid(id);

            if (obj != null)
            {
                rp.Code = 0;
                rp.Message = obj;
            }

            return Json(rp, JsonRequestBehavior.AllowGet);

        }
    }
}