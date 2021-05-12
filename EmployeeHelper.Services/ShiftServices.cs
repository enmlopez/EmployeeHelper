using EmployeeHelper.Contracts;
using EmployeeHelper.Data;
using EmployeeHelper.Models.EmployeeModels;
using EmployeeHelper.Models.ShiftModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeHelper.Services
{
    public class ShiftServices : IShiftServices
    {
        public bool CreateShift(ShiftCreate model)
        {
            var entity =
                new ShiftTable()
                {
                    Shift = model.Shift
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Shifts.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ShiftListItem> GetShift()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Shifts.Select(e => new ShiftListItem
                {
                    ShiftId = e.ShiftId,
                    Shift = e.Shift
                });
                return query.ToArray();
            }
        }

        public ShiftDetail GetShiftById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Shifts.SingleOrDefault(e => e.ShiftId == id);

                return new ShiftDetail
                {
                    ShiftId = entity.ShiftId,
                    Shift = entity.Shift,
                    EmployeePerShift = entity.ShiftEmployees.Select(e => new EmployeeListItem
                    {
                        EmployeeId = e.EmployeeId,
                        FirstName = e.FirstName,
                        LastName = e.LastName,
                        HiringDate = e.HiringDate
                    }).ToList()
                };
            }
        }

        public bool UpdateShift(ShiftEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Shifts.SingleOrDefault(e => e.ShiftId == model.ShiftId);

                entity.Shift = model.Shift;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteShift(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Shifts.SingleOrDefault(e => e.ShiftId == id);

                ctx.Shifts.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
