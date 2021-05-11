using EmployeeHelper.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeHelper.Models.ShiftModels
{
    public class ShiftListItem
    {
        public int ShiftId { get; set; }

        public Shift Shift { get; set; }
    }
}
