using EmployeeHelper.Data; // remove if not needed
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeHelper.Models.OTModels
{
    public class OverTimeDetail
    {
        [Display(Name = "ID")]
        public int OTId { get; set; }

        [Display(Name = "Available?")]
        public bool IsAvailable { get; set; }

        [Display(Name = "OT")]
        public DateTime OTDay { get; set; }

        [Display(Name = "Hours?")]
        public decimal? HoursWorked { get; set; }

        public Days Days { get; set; }

        public string Employee { get; set; }
    }
}
