using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClinicManagementSystem.Iservises
{
    public interface IStaff
    {

        List<tblStaff> GetAll();

        tblStaff Findbyid(int id);

        string Save(tblStaff obj);

        bool Delete(int id);

        dynamic GetAllkey(string key);

        dynamic GetAllPage(int pagno);




    }
}