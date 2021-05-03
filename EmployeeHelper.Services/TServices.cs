using EmployeeHelper.Data;
using EmployeeHelper.Models.TModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeHelper.Services
{
    public class TServices
    {
        public bool TCreate(TCreate model)
        {
            TamcTymcSamples entity = new TamcTymcSamples()
            {
                DueOnDate = model.DueOnDate,
                IsComplete = false
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.TamcTymcSamples.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<TListItem> GetT()
        {
            using (var ctx = new ApplicationDbContext())
            {
                IEnumerable<TListItem> query = ctx
                    .TamcTymcSamples
                    .Select(e => new TListItem
                    {
                        TId = e.TId,
                        IsComplete = e.IsComplete,
                        DueOnDate = e.DueOnDate
                    });
                return query.ToArray();
            }
        }

        public TDetail GetTById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                TamcTymcSamples entity = ctx.TamcTymcSamples.SingleOrDefault(e => e.TId == id);
                if (entity.Employee != null)
                {
                    return new TDetail
                    {
                        TId = entity.TId,
                        IsComplete = entity.IsComplete,
                        DueOnDate = entity.DueOnDate,
                        CompletedOnDate = entity.CompletedOnDate,
                        Employee = entity.Employee.FirstName + " " + entity.Employee.LastName
                    };
                }
                else
                {
                    return new TDetail
                    {
                        TId = entity.TId,
                        IsComplete = entity.IsComplete,
                        DueOnDate = entity.DueOnDate,
                        CompletedOnDate = entity.CompletedOnDate
                    };
                }
            }
        }

        public bool UpdateT(TEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                TamcTymcSamples entity = ctx.TamcTymcSamples.SingleOrDefault(e => e.TId == model.TId);
                //entity.CompletedOnDate = DateTime.Now;
                entity.DueOnDate = model.DueOnDate;
                entity.IsComplete = model.IsComplete;
                entity.EmployeeId = model.EmployeeId;

                return ctx.SaveChanges() == 1;
            }
        }
        //TEST
        public bool UpdateTCompletedBy(TEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                TamcTymcSamples entity = ctx.TamcTymcSamples.SingleOrDefault(e => e.TId == model.TId);
                //entity.DueOnDate = model.DueOnDate;
                entity.CompletedOnDate = DateTime.Now;
                entity.IsComplete = true;
                entity.EmployeeId = model.EmployeeId;

                return ctx.SaveChanges() == 1;
            }
        }

        //END OF TEST

        public bool DeleteT(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                TamcTymcSamples entity = ctx.TamcTymcSamples.SingleOrDefault(e => e.TId == id);

                ctx.TamcTymcSamples.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }

}
