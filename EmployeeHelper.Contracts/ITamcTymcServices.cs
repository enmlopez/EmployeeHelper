using EmployeeHelper.Models.TModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeHelper.Contracts
{
    public interface ITamcTymcServices
    {
        bool TCreate(TCreate model);
        IEnumerable<TListItem> GetT();
        TDetail GetTById(int id);
        bool UpdateT(TEdit model);
        bool UpdateTCompletedBy(TEdit model);
        bool DeleteT(int id);
    }
}
