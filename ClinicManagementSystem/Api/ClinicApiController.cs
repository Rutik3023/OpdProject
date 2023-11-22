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
    public class ClinicApiController : Controller
    {
        // GET: Clinic
        IClinic c;
        Mapper mp = null;

        public ClinicApiController(IClinic _c)
        {
            var config = new MapperConfiguration(u => u.CreateMap<VMClinic, tblClinic>().ReverseMap());
            mp = new Mapper(config);

            c = _c;
        }


        // GET: Api
        public JsonResult GetAllC(int pagno)
        {
            Reports rp = new Reports();

            var obj = c.GetAll();
            var objt = c.GetAllPage(pagno);

            List<VMClinic> list = mp.Map<List<VMClinic>>(objt);

            rp.pageno = pagno;
            rp.count = obj.Count();
            rp.Code = 0;
            rp.Message = list;

            return Json(rp, JsonRequestBehavior.AllowGet);
        }


        public JsonResult FindByid(int id)
        {
            Reports rp = new Reports();

            var obj = c.Findbyid(id);
            VMClinic list = mp.Map<VMClinic>(obj);

            rp.Code = 0;
            rp.Message = list;
            return Json(rp, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Save(VMClinic obj)
        {
            obj.Mobile = "5451";
            
            Reports rp = new Reports();
            tblClinic list = mp.Map<tblClinic>(obj);
            
            var res = c.Save(list);

            rp.Code = 0;
            rp.Message = res;

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