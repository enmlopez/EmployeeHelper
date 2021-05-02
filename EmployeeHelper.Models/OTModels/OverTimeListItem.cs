using EmployeeHelper.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeHelper.Models.OTModels
{
    public class OverTimeListItem
    {
        [Display(Name = "ID")]
        public int OTId { get; set; }

        [Display(Name = "OT")]
        public DateTime OTDay { get; set; }

        [Display(Name = "Available ?")]
        public bool IsAvailable { get; set; }

        [Display(Name ="Day/Night")]
        public Days Days { get; set; }
    }
}
