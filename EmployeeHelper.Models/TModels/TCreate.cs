using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeHelper.Models.TModels
{
    public class TCreate
    {
        [Display(Name = "Due Date")]
        public DateTime DueOnDate { get; set; }
        public bool IsComplete { get; set; }
    }
}
