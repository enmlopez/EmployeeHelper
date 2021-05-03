using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeHelper.Data
{
    public class TamcTymcSamples
    {
        [Key]
        public int TId { get; set; }

        public bool IsComplete { get; set; }

        [Required]
        public DateTime DueOnDate { get; set; }

        public DateTime? CompletedOnDate { get; set; }

        [ForeignKey(nameof(Employee))]
        public int? EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
