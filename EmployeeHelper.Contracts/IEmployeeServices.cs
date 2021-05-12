using EmployeeHelper.Models.EmployeeModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeHelper.Contracts
{
    public interface IEmployeeServices
    {
        bool CreateEmployee(EmployeeCreate model);
        IEnumerable<EmployeeListItem> GetEmployees();
        EmployeeDetail GetEmployeeById(int id);
        bool UpdateEmployee(EmployeeEdit model);
        bool DeleteEmployee(int id);
    }
}
