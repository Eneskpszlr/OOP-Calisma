using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem
{
    public interface IStaffService
    {
        void RegisterStaff(Staff staff);
        void AssignRoleStaff(Guid staffId, RoleStatus role);
        string GetStaffShifts(Guid staffId);
    }
}
