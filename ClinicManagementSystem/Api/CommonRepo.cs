using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClinicManagementSystem.Api
{
    public static class CommonRepo
    {
        public static List<SelectListItem> Clinic()
        {
            List<SelectListItem> list = new List<SelectListItem>();

            using (var ctx = new HospitalDBEntities())
            {
                var tlist = ctx.tblClinics.Select(s => new { s.Id, s.Name }).ToList();

                foreach (var item in tlist)
                {
                    SelectListItem o = new SelectListItem();
                    o.Text = item.Name;
                    o.Value = item.Id.ToString();
                    list.Add(o);

                }


            }





            return list;
        }

        public static List<SelectListItem> Role()
        {
            List<SelectListItem> list = new List<SelectListItem>();

            using (var ctx = new HospitalDBEntities())
            {
                var tlist = ctx.tblRoles.Select(s => new { s.Id, s.Role }).ToList();

                foreach (var item in tlist)
                {
                    SelectListItem o = new SelectListItem();
                    o.Text = item.Role;
                    o.Value = item.Id.ToString();
                    list.Add(o);

                }


            }





            return list;
        }

        internal static string GetAdditionValidaitonIssues(ModelStateDictionary modelState)
        {
            var errors = modelState.Select(x => x.Value.Errors)
                            .Where(y => y.Count > 0)
                            .ToList();

            string str = "";
            foreach (var item in errors)
            {
                str = str + ", " + item[0].ErrorMessage.ToString();
            }
            return "Validation failed." + str.Substring(1);
        }


        public static List<SelectListItem> Blood()
        {
            List<SelectListItem> list = new List<SelectListItem>();

            using (var ctx = new HospitalDBEntities())
            {
                var tlist = ctx.tblBloodgroups.Select(s => new { s.Id, s.Name }).ToList();

                foreach (var item in tlist)
                {
                    SelectListItem o = new SelectListItem();
                    o.Text = item.Name;
                    o.Value = item.Id.ToString();
                    list.Add(o);

                }


            }

            return list;
        }
    }
}