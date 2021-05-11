using EmployeeHelper.Data;
using EmployeeHelper.Models.EmployeeModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeHelper.Models.ShiftModels
{
    public class ShiftDetail
    {
        public int ShiftId { get; set; }
        public Shift Shift { get; set; }
        public virtual List<EmployeeListItem> EmployeePerShift { get; set; }
    }
}
