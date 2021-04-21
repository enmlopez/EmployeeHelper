using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeHelper.Models.OTModels
{
    public class OverTimeCreate
    {
        [Required]
        [Display(Name = "Available?")]
        public bool IsAvailable { get; set; }

        [Required]
        [Display(Name = "OverTime")]
        public DateTimeOffset OTDay { get; set; }
    }
}
