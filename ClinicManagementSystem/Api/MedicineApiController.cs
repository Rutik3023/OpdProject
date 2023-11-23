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
    public class MedicineApiController : Controller
    {
        // GET: AppointmentApi
       IMedicine  c;
        Mapper mp = null;
        public MedicineApiController(IMedicine _c)
        {
            var config = new MapperConfiguration(u => u.CreateMap<VMMedicine, tblMedicine>().ReverseMap());
            mp = new Mapper(config);

            c = _c;

        }


        // GET: Api


        public JsonResult GetAllC(int pagno)
        {
            Reports rp = new Reports();

            var obj = c.GetAll();
            var objt = c.GetAllPage(pagno);

            List<VMMedicine> list = mp.Map<List<VMMedicine>>(objt);




            rp.pageno = pagno;
            rp.count = obj.Count();
            rp.Code = 0;
            rp.Message = list;

            return Json(rp, JsonRequestBehavior.AllowGet);
        }


        public JsonResult FindByid(int id)
        {
            Reports rp = new Reports();

            var obj = c.FindById(id);
            VMMedicine list = mp.Map<VMMedicine>(obj);

            rp.Code = 0;
            rp.Message = list;
            return Json(rp, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Save(VMMedicine obj)
        {
            Reports rp = new Reports();

            tblMedicine list = mp.Map<tblMedicine>(obj);
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
    }
}