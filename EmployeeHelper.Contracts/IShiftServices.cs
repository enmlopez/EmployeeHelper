using EmployeeHelper.Models.ShiftModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeHelper.Contracts
{
    public interface IShiftServices
    {
        bool CreateShift(ShiftCreate model);
        IEnumerable<ShiftListItem> GetShift();
        ShiftDetail GetShiftById(int id);
        bool UpdateShift(ShiftEdit model);
        bool DeleteShift(int id);
    }
}
