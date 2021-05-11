using EmployeeHelper.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeHelper.Models.EmployeeModels
{
    public class EmployeeListItem
    {
        [Display(Name = "Employee ID")]
        public int EmployeeId { get; set; }

        [Display(Name = "First Name")]
        [MaxLength(10, ErrorMessage = "Too many characters")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [MaxLength(10, ErrorMessage = "Too many characters")]
        public string LastName { get; set; }
        public Shift Shift { get; set; }
        //test
        public DateTime HiringDate { get; set; }
    }
}
