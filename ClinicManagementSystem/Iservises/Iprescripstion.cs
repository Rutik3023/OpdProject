using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClinicManagementSystem.Iservises
{
    public interface Iprescripstion
    {
        dynamic lodCasid(int id);
        dynamic lodAppoymentid(int id);
    }
}