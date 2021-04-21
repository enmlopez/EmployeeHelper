﻿using EmployeeHelper.Data;
using EmployeeHelper.Models.OTModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeHelper.Services
{
    public class OverTimeServices
    {
        public bool OTCreate(OverTimeCreate model)
        {
            OverTime entity = new OverTime()
            {
                IsAvailable = model.IsAvailable,
                OTDay = model.OTDay,
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
                        IsAvailable = e.IsAvailable
                    });
                return query.ToArray();
            }
        }

        public OverTimeDetail GetOTById(int id)
        {
            using (ApplicationDbContext ctx = new ApplicationDbContext())
            {
                OverTime entity = ctx.OverTimeDays.SingleOrDefault(e => e.OTId == id);
                return new OverTimeDetail
                {
                    OTId = entity.OTId,
                    OTDay = entity.OTDay,
                    IsAvailable = entity.IsAvailable,
                    HoursWorked = entity.HoursWorked,
                    Employee = entity.Employee.FirstName + "" + entity.Employee.LastName
                };

            }
        }
    }
}
