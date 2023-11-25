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
    public class StaffApiController : Controller
    {
        IStaff c;
        Mapper mp = null;
        public StaffApiController(IStaff _c)
        {
            var config = new MapperConfiguration(u => u.CreateMap<VMStaff, tblStaff>().ReverseMap());
            mp = new Mapper(config);

            c = _c;

        }


        // GET: Api


        public JsonResult GetAllC(int pagno)
        {
            Reports rp = new Reports();

           
            var objt = c.GetAllPage(pagno);

           // List<VMStaff> list = mp.Map<List<VMStaff>>(objt);




            rp.pageno = pagno;
           
            rp.Code = 0;
            rp.Message = objt;

            return Json(rp, JsonRequestBehavior.AllowGet);
        }


        public JsonResult FindByid(int id)
        {
            Reports rp = new Reports();

            var obj = c.Findbyid(id);
            VMStaff list = mp.Map<VMStaff>(obj);

            rp.Code = 0;
            rp.Message = list;
            return Json(rp, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Save(VMStaff obj)

        {


            Reports rp = new Reports();
            tblStaff list = mp.Map<tblStaff>(obj);
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
                rp.Message = "Deleated  Sucusessfully";
            }



            return Json(rp, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetAll(string key)
        {
            Reports rp = new Reports();

            var obj = c.GetAllkey(key);

            if (obj != null)
            {
                rp.Code = 0;
                rp.Message = obj;
            }

            return Json(rp, JsonRequestBehavior.AllowGet);

        }

    }
}