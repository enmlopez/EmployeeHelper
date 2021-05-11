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
        A,
        B,
        C,
        D
    }

    public class ShiftTable
    {
        [Key]
        public int ShiftId { get; set; }

        [Required]
        public Shift Shift { get; set; }

        public virtual List<Employee> ShiftEmployees { get; set; }
    }
}
