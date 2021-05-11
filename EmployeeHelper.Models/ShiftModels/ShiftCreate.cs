using EmployeeHelper.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeHelper.Models.ShiftModels
{
    public class ShiftCreate
    {
        [Required]
        public Shift Shift { get; set; }
    }
}
