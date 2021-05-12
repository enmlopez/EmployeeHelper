using EmployeeHelper.Models.BTModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeHelper.Contracts
{
    public interface IBTServices
    {
        bool BTCreate(BTCreate model);
        IEnumerable<BTListItem> GetBT();
        BTDetail GetBTById(int id);
        bool UpdateBT(BTEdit model);
        bool UpdateBTCompletedBy(BTEdit model);
        bool DeleteBT(int id);
    }
}
