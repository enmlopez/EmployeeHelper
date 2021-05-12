using EmployeeHelper.Contracts;
using EmployeeHelper.Data;
using EmployeeHelper.Models.OTModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeHelper.Services
{
    public class OverTimeServices : IOverTimeServices
    {
        public bool OTCreate(OverTimeCreate model)
        {
            OverTime entity = new OverTime()
            {
                IsAvailable = false,
                OTDay = model.OTDay,
                HoursWorked = model.HoursWorked,
                EmployeeId = model.EmployeeId,
                Days = model.Days
            };

            using (ApplicationDbContext ctx = new ApplicationDbContext())
            {
                ctx.OverTimeDays.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<OverTimeListItem> GetOT()
        {
            using (ApplicationDbContext ctx = new ApplicationDbContext())
            {
                IEnumerable<OverTimeListItem> query = ctx
                    .OverTimeDays
                    .Select(e => new OverTimeListItem
                    {
                        OTId = e.OTId,
                        OTDay = e.OTDay,
                        IsAvailable = e.IsAvailable,
                        Days = e.Days
                    });
                return query.ToArray();
            }
        }

        public OverTimeDetail GetOTById(int id)
        {
            using (ApplicationDbContext ctx = new ApplicationDbContext())
            {
                OverTime entity = ctx.OverTimeDays.SingleOrDefault(e => e.OTId == id);
                if (entity.Employee != null)
                {
                    return new OverTimeDetail
                    {
                        OTId = entity.OTId,
                        OTDay = entity.OTDay,
                        IsAvailable = entity.IsAvailable,
                        HoursWorked = entity.HoursWorked,
                        Days = entity.Days,
                        Employee = entity.Employee.FirstName + " " + entity.Employee.LastName
                    };
                }
                else if(entity.Employee is null)
                {
                    return new OverTimeDetail
                    {
                        OTId = entity.OTId,
                        OTDay = entity.OTDay,
                        IsAvailable = entity.IsAvailable,
                        HoursWorked = entity.HoursWorked,
                        Days = entity.Days,
                    };
                }
                else
                {
                    return new OverTimeDetail
                    {
                        OTId = entity.OTId,
                        OTDay = entity.OTDay,
                        IsAvailable = entity.IsAvailable,
                        HoursWorked = entity.HoursWorked,
                        Days = entity.Days,
                    };
                }

            }
        }

        public bool UpdateOverTime(OverTimeEdit model)
        {
            using (ApplicationDbContext ctx = new ApplicationDbContext())
            {
                OverTime entity = ctx.OverTimeDays.SingleOrDefault(e => e.OTId == model.OTId);
                //entity.IsAvailable = model.IsAvailable;
                entity.OTDay = model.OTDay;
                //entity.HoursWorked = model.HoursWorked;
                //entity.EmployeeId = model.EmployeeId;
                entity.Days = model.Days;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool WorkOverTime(OverTimeWork model)
        {
            using (ApplicationDbContext ctx = new ApplicationDbContext())
            {
                OverTime entity = ctx.OverTimeDays.SingleOrDefault(e => e.OTId == model.OTId);
                entity.IsAvailable = true;
                entity.OTDay = model.OTDay;
                entity.HoursWorked = model.HoursWorked;
                entity.EmployeeId = model.EmployeeId;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteOverTime(int id)
        {
            using (ApplicationDbContext ctx = new ApplicationDbContext())
            {
                OverTime entity = ctx.OverTimeDays.SingleOrDefault(e => e.OTId == id);

                ctx.OverTimeDays.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
