using EmployeeHelper.Models.OTModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeHelper.Contracts
{
    public interface IOverTimeServices
    {
        bool OTCreate(OverTimeCreate model);
        IEnumerable<OverTimeListItem> GetOT();
        OverTimeDetail GetOTById(int id);
        bool UpdateOverTime(OverTimeEdit model);
        bool WorkOverTime(OverTimeWork model);
        bool DeleteOverTime(int id);
    }
}
