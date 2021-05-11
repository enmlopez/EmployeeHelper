using EmployeeHelper.Data;
using EmployeeHelper.Models.BTModels;
using EmployeeHelper.Models.BufferModels;
//test
using EmployeeHelper.Models.OTModels;
using EmployeeHelper.Models.TModels;
//end test
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeHelper.Models.EmployeeModels
{
    public class EmployeeDetail
    {
        [Display(Name = "ID")]
        public int EmployeeId { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Hiring Date")]
        public DateTime HiringDate { get; set; }

        public Shift Shifts { get; set; }

        public virtual List<OverTimeListItem> OTList { get; set; }

        //test
        public virtual List<BTListItem> BTList { get; set; }

        public virtual List<TListItem> TList { get; set; }

        public virtual List<BufferListItem> BufferList { get; set; }
        //end test
    }
}
