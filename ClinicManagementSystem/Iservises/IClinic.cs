using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClinicManagementSystem.Iservises
{
    public interface IClinic
    {
        List<tblClinic> GetAll();

        tblClinic Findbyid(int id);
        
        string Save(tblClinic obj);

        bool Delete(int id);

        dynamic GetAllkey( string key);

        dynamic GetAllPage(int pagno);


    }
}