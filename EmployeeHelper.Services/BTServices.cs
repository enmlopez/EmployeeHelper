using EmployeeHelper.Contracts;
using EmployeeHelper.Data;
using EmployeeHelper.Models.BTModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeHelper.Services
{
    public class BTServices : IBTServices
    {
        public bool BTCreate(BTCreate model)
        {
            BulkTechSamples entity = new BulkTechSamples()
            {
                DueOnDate = model.DueOnDate,
                IsComplete = false
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.BulkTechSamples.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<BTListItem> GetBT()
        {
            using (var ctx = new ApplicationDbContext())
            {
                IEnumerable<BTListItem> query = ctx
                    .BulkTechSamples
                    .Select(e => new BTListItem
                    {
                        BTId = e.BTId,
                        IsComplete = e.IsComplete,
                        DueOnDate = e.DueOnDate
                    });
                return query.ToArray();
            }
        }

        public BTDetail GetBTById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                BulkTechSamples entity = ctx.BulkTechSamples.SingleOrDefault(e => e.BTId == id);
                if (entity.Employee != null)
                {
                    return new BTDetail
                    {
                        BTId = entity.BTId,
                        IsComplete = entity.IsComplete,
                        DueOnDate = entity.DueOnDate,
                        CompletedOnDate = entity.CompletedOnDate,
                        Employee = entity.Employee.FirstName + " " + entity.Employee.LastName
                    };
                }
                else
                {
                    return new BTDetail
                    {
                        BTId = entity.BTId,
                        IsComplete = entity.IsComplete,
                        DueOnDate = entity.DueOnDate,
                        CompletedOnDate = entity.CompletedOnDate
                    };
                }
            }
        }

        public bool UpdateBT(BTEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                BulkTechSamples entity = ctx.BulkTechSamples.SingleOrDefault(e => e.BTId == model.BTId);
                //entity.CompletedOnDate = DateTime.Now;
                entity.DueOnDate = model.DueOnDate;
                entity.IsComplete = model.IsComplete;
                entity.EmployeeId = model.EmployeeId;

                return ctx.SaveChanges() == 1;
            }
        }
        //TEST
        public bool UpdateBTCompletedBy(BTEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                BulkTechSamples entity = ctx.BulkTechSamples.SingleOrDefault(e => e.BTId == model.BTId);
                //entity.DueOnDate = model.DueOnDate;
                entity.CompletedOnDate = DateTime.Now;
                entity.IsComplete = true;
                entity.EmployeeId = model.EmployeeId;

                return ctx.SaveChanges() == 1;
            }
        }

        //END OF TEST

        public bool DeleteBT(int id)
        {
            using(var ctx = new ApplicationDbContext())
            {
                BulkTechSamples entity = ctx.BulkTechSamples.SingleOrDefault(e=> e.BTId == id);

                ctx.BulkTechSamples.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }

}
