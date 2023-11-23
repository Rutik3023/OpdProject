using AutoMapper;
using ClinicManagementSystem.Iservises;
using ClinicManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClinicManagementSystem.Api
{
    public class PatientApiController : Controller
    {
        // GET: Clinic
        IPatient c;
        Mapper mp = null;
        public PatientApiController(IPatient _c)
        {
            var config = new MapperConfiguration(u => u.CreateMap<VMPatient,tblPatient>().ReverseMap());
            mp = new Mapper(config);

            c = _c;

        }


        // GET: Api


        public JsonResult GetAllC(int pagno)
        {
            Reports rp = new Reports();

            var obj = c.GetAll();
            var objt = c.GetAllPage(pagno);

            //List<VMPatient> list = mp.Map<List<VMPatient>>(objt);




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
            VMPatient list = mp.Map<VMPatient>(obj);

            rp.Code = 0;
            rp.Message = list;
            return Json(rp, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Save(VMPatient obj)
        {
            //  ModelState.Clear();
            Reports rp = new Reports();


            tblPatient list = mp.Map<tblPatient>(obj);


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