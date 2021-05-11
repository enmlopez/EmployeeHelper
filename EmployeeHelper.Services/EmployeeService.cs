using EmployeeHelper.Data;
using EmployeeHelper.Models.BTModels;
using EmployeeHelper.Models.BufferModels;
using EmployeeHelper.Models.EmployeeModels;
using EmployeeHelper.Models.OTModels;
using EmployeeHelper.Models.ShiftModels;
using EmployeeHelper.Models.TModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeHelper.Services
{
    public class EmployeeService
    {
        private readonly Guid _userId;

        public EmployeeService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateEmployee(EmployeeCreate model)
        {
            Employee entity = new Employee()
            {
                EmployeeGuid = _userId,
                FirstName = model.FirstName,
                LastName = model.LastName,
                HiringDate = model.HiringDate,
                ShiftId = model.ShiftId
            };

            using (ApplicationDbContext ctx = new ApplicationDbContext())
            {
                ctx.Employees.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<EmployeeListItem> GetEmployees()
        {
            using (ApplicationDbContext ctx = new ApplicationDbContext())
            {
                IEnumerable<EmployeeListItem> query =
                    ctx
                    .Employees
                    .Where(e => e.EmployeeGuid == _userId)
                    .Select(e => new EmployeeListItem
                    {
                        EmployeeId = e.EmployeeId,
                        FirstName = e.FirstName,
                        LastName = e.LastName,
                        Shift = e.Shift.Shift,
                        HiringDate = e.HiringDate,
                    });

                return query.ToArray();
            }
        }

        public EmployeeDetail GetEmployeeById(int id)
        {
            using (ApplicationDbContext ctx = new ApplicationDbContext())
            {
                Employee entity =
                    ctx.
                    Employees.
                    SingleOrDefault(e => e.EmployeeId == id && e.EmployeeGuid == _userId);
                return new EmployeeDetail()
                {
                    EmployeeId = entity.EmployeeId,
                    FirstName = entity.FirstName,
                    LastName = entity.LastName,
                    HiringDate = entity.HiringDate.Date,
                    Shifts = entity.Shift.Shift,
                    OTList = entity.ListOfOvertime.Select(e => new OverTimeListItem
                    {
                        OTId = e.OTId,
                        OTDay = e.OTDay,
                        Days = e.Days
                    }).ToList(),
                    BTList = entity.ListOfBTSamples.Select(e => new BTListItem
                    {
                        BTId = e.BTId,
                        DueOnDate = e.DueOnDate,
                        IsComplete = e.IsComplete
                    }).ToList(),
                    TList = entity.ListOfTSamples.Select(e => new TListItem
                    {
                        TId = e.TId,
                        DueOnDate = e.DueOnDate,
                        IsComplete = e.IsComplete
                    }).ToList(),
                    BufferList = entity.ListOfBufferDates.Select(e => new BufferListItem
                    {
                        BufferId = e.BufferId,
                        DueOnDate = e.DueOnDate,
                        IsComplete = e.IsComplete
                    }).ToList()
                };
            }
        }

        public bool UpdateEmployee(EmployeeEdit model)
        {
            using (ApplicationDbContext ctx = new ApplicationDbContext())
            {
                Employee entity = ctx.Employees.SingleOrDefault(e => e.EmployeeId == model.EmployeeId && e.EmployeeGuid == _userId);
                entity.FirstName = model.FirstName;
                entity.LastName = model.LastName;
                entity.HiringDate = model.HiringDate;
                //entity.Shifts = model.Shifts;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteEmployee(int id)
        {
            using (ApplicationDbContext ctx = new ApplicationDbContext())
            {
                Employee entity = ctx.Employees.SingleOrDefault(e => e.EmployeeId == id && e.EmployeeGuid == _userId);

                ctx.Employees.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
