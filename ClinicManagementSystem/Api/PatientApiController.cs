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
        // GET: PatientApi
        IPatient c;
        Mapper mp = null;
        public PatientApiController(IPatient _c)
        {
            var config = new MapperConfiguration(u => u.CreateMap<VMPatient, tblPatient>().ReverseMap());
            mp = new Mapper(config);

            c = _c;

        }


        // GET: Api


        public JsonResult GetAllC(int pagno)
        {
            Reports rp = new Reports();

            var obj = c.GetAll();
            var objt = c.GetAllPage(pagno);

            List<VMPatient> list = mp.Map<List<VMPatient>>(objt);




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
            VMPatient list = mp.Map<VMPatient>(obj);

            rp.Code = 0;
            rp.Message = list;
            return Json(rp, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Save(VMPatient obj)
        {
            Reports rp = new Reports();
            obj.Photo = rp.Path;





            tblPatient list = mp.Map<tblPatient>(obj);
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

        [HttpPost]
        public void Upload()
        {
            Reports rp = new Reports();
            if (Request.Files.Count != 0)
            {

                for (int i = 0; i < Request.Files.Count; i++)
                {
                    var file = Request.Files[i];

                    var fileName = Path.GetFileName(file.FileName);
                    rp.Path = file.FileName;
                    var path = Path.Combine(Server.MapPath("~/DoctorPhoto/"), fileName);
                    file.SaveAs(path);

                    //string path = Server.MapPath("~/DoctorPhoto/");
                    //file.SaveAs(path + file.FileName);






                }

            }

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