using EmployeeHelper.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeHelper.Models.OTModels
{
    public class OverTimeWork
    {
        [Display(Name = "ID")]
        public int OTId { get; set; }

        [Required]
        [Display(Name = "Available?")]
        public bool IsAvailable { get; set; }

        [Required]
        [Display(Name = "OT")]
        public DateTime OTDay { get; set; }

        [Required]
        [Display(Name = "Hours?")]
        public decimal? HoursWorked { get; set; }

        public Days Days { get; set; }

        public int? EmployeeId { get; set; }
    }
}
