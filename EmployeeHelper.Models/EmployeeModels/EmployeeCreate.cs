using EmployeeHelper.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeHelper.Models.EmployeeModels
{
    public class EmployeeCreate
    {
        [Required]
        [Display(Name = "First Name")]
        [MaxLength(10, ErrorMessage = "Too many characters")]
        [MinLength(2, ErrorMessage = "Try something longer")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [MaxLength(10, ErrorMessage = "Too many characters")]
        [MinLength(2, ErrorMessage = "Try something longer")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Hiring Date")]
        public DateTime HiringDate { get; set; }

        [Required]
        public Shift Shift { get; set; }

    }
}
