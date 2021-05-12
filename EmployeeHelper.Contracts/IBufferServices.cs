using EmployeeHelper.Models.BufferModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeHelper.Contracts
{
    public interface IBufferServices
    {
        bool BufferCreate(BufferCreate model);
        IEnumerable<BufferListItem> GetBuffer();
        BufferDetail GetBufferById(int id);
        bool UpdateBuffer(BufferEdit model);
        bool UpdateBufferCompletedBy(BufferEdit model);
        bool DeleteBuffer(int id);
    }
}
