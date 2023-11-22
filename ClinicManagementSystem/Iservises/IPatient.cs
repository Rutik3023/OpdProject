using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClinicManagementSystem.Iservises
{
    public interface IPatient
    {
        List<tblPatient> GetAll();

        string Save(tblPatient obj);

        tblPatient FindById(int id);

        bool Delete(int id);

        dynamic GetAllKey(string key);

        dynamic GetAllPage(int Pageno);
    }
}