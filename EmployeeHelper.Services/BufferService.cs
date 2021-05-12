using EmployeeHelper.Contracts;
using EmployeeHelper.Data;
using EmployeeHelper.Models.BufferModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeHelper.Services
{
    public class BufferServices : IBufferServices
    {
        public bool BufferCreate(BufferCreate model)
        {
            BufferReplacement entity = new BufferReplacement()
            {
                DueOnDate = model.DueOnDate,
                IsComplete = false
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.BufferReplacements.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<BufferListItem> GetBuffer()
        {
            using (var ctx = new ApplicationDbContext())
            {
                IEnumerable<BufferListItem> query = ctx
                    .BufferReplacements
                    .Select(e => new BufferListItem
                    {
                        BufferId = e.BufferId,
                        IsComplete = e.IsComplete,
                        DueOnDate = e.DueOnDate
                    });
                return query.ToArray();
            }
        }

        public BufferDetail GetBufferById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                BufferReplacement entity = ctx.BufferReplacements.SingleOrDefault(e => e.BufferId == id);
                if (entity.Employee != null)
                {
                    return new BufferDetail
                    {
                        BufferId = entity.BufferId,
                        IsComplete = entity.IsComplete,
                        DueOnDate = entity.DueOnDate,
                        CompletedOnDate = entity.CompletedOnDate,
                        Employee = entity.Employee.FirstName + " " + entity.Employee.LastName
                    };
                }
                else
                {
                    return new BufferDetail
                    {
                        BufferId = entity.BufferId,
                        IsComplete = entity.IsComplete,
                        DueOnDate = entity.DueOnDate,
                        CompletedOnDate = entity.CompletedOnDate
                    };
                }
            }
        }

        public bool UpdateBuffer(BufferEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                BufferReplacement entity = ctx.BufferReplacements.SingleOrDefault(e => e.BufferId == model.BufferId);
                //entity.CompletedOnDate = DateTime.Now;
                entity.DueOnDate = model.DueOnDate;
                entity.IsComplete = model.IsComplete;
                entity.EmployeeId = model.EmployeeId;

                return ctx.SaveChanges() == 1;
            }
        }
        //TEST
        public bool UpdateBufferCompletedBy(BufferEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                BufferReplacement entity = ctx.BufferReplacements.SingleOrDefault(e => e.BufferId == model.BufferId);
                //entity.DueOnDate = model.DueOnDate;
                entity.CompletedOnDate = DateTime.Now;
                entity.IsComplete = true;
                entity.EmployeeId = model.EmployeeId;

                return ctx.SaveChanges() == 1;
            }
        }

        //END OF TEST

        public bool DeleteBuffer(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                BufferReplacement entity = ctx.BufferReplacements.SingleOrDefault(e => e.BufferId == id);

                ctx.BufferReplacements.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }

}
