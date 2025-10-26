using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem
{
    public interface IManagerService
    {
        void AssignStaffToManager(Guid managerId, Guid staffId);
        void GetManagerStaff(Guid managerId);
    }
}
