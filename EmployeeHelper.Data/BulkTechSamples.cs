using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeHelper.Data
{
    public class BulkTechSamples
    {
        [Key]
        public int BTId { get; set; }
        public bool IsComplete { get; set; }
        public DateTimeOffset CompletionDate { get; set; }
        public int? EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
