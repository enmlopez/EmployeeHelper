using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeHelper.Models.BufferModels
{
    public class BufferEdit
    {
        [Display(Name = "ID")]
        public int BufferId { get; set; }

        [Display(Name = "Complete?")]
        public bool IsComplete { get; set; }

        [Display(Name = "Due Date")]
        public DateTime DueOnDate { get; set; }

        [Display(Name = "Completion Date")]
        public DateTime? CompletedOnDate { get; set; }

        public int? EmployeeId { get; set; }
    }
}
