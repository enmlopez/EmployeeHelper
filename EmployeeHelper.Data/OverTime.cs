using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeHelper.Data
{
    public enum Days
    {
        Day = 0,
        Night
    }
    public class OverTime
    {
        [Key]
        public int OTId { get; set; }

        [Required]
        public bool IsAvailable { get; set; }

        [Required]
        public DateTime OTDay { get; set; }

        public decimal? HoursWorked { get; set; }

        public Days Days { get; set; }

        [ForeignKey(nameof(Employee))]
        public int? EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
