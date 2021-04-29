using EmployeeHelper.Data;
using EmployeeHelper.Models.BTModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeHelper.Services
{
    public class BTServices
    {
        public bool BTCreate(BTCreate model)
        {
            BulkTechSamples entity = new BulkTechSamples()
            {
                DueOnDate = model.DueOnDate
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.BulkTechSamples.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

    }
}
