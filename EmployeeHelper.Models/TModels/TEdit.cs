using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeHelper.Models.TModels
{
    public class TEdit
    {
        [Display(Name = "ID")]
        public int TId { get; set; }

        [Display(Name = "Complete?")]
        public bool IsComplete { get; set; }

        [Display(Name = "Due Date")]
        public DateTime DueOnDate { get; set; }

        [Display(Name = "Completion Date")]
        public DateTime? CompletedOnDate { get; set; }

        public int? EmployeeId { get; set; }
    }
}
