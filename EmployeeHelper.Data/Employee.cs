using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeHelper.Data
{
    public enum Shift
    {
        A = 0,
        B,
        C,
        D
    }
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

        public virtual List<OverTime> ListOfOvertime { get; set; } = new List<OverTime>();
        //Test
        public virtual List<BulkTechSamples> ListOfBTSamples { get; set; } = new List<BulkTechSamples>();
        //end test
    }
}
