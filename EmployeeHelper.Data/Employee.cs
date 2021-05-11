using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeHelper.Data
{
    
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }

        [Required]
        public Guid EmployeeGuid { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public Shift Shifts { get; set; }

        [Required]
        public DateTime HiringDate { get; set; }

        [ForeignKey(nameof(Shift))]
        public int ShiftId { get; set; }
        public virtual ShiftTable Shift { get; set; }

        public virtual List<OverTime> ListOfOvertime { get; set; } = new List<OverTime>();
        //Test
        public virtual List<BulkTechSamples> ListOfBTSamples { get; set; } = new List<BulkTechSamples>();

        public virtual List<TamcTymcSamples> ListOfTSamples { get; set; } = new List<TamcTymcSamples>();

        public virtual List<BufferReplacement> ListOfBufferDates { get; set; } = new List<BufferReplacement>();
        //end test
    }
}
