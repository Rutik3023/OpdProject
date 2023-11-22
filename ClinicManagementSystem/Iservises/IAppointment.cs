using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClinicManagementSystem.Iservises
{
    public interface IAppointment
    {
        List<tblAppointment> GetAll();

        string Save(tblAppointment obj);

        tblAppointment FindById(int id);

        bool Delete(int id);

        dynamic GetAllKey(string key);

        dynamic GetAllPage(int pageno);


        dynamic loadCasid(int id);

    }
}