using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem
{
    public class StaffService : IStaffService
    {
        private readonly IRepository<Staff> _staffRepository;

        public StaffService(IRepository<Staff> staffRepository)
        {
            _staffRepository = staffRepository;
        }

        public void AssignRoleStaff(Guid staffId, RoleStatus role)
        {
            var existStaff = _staffRepository.GetById(staffId);
            if (existStaff == null)
            {
                Console.WriteLine("Böyle bir staff bulunmamaktadır.");
            }
            else
            {
                existStaff.Role = role;
                Console.WriteLine("Staff'a başarıyla rol atandı.");
            }
        }

        public string GetStaffShifts(Guid staffId)
        {
            var existStaff = _staffRepository.GetById(staffId);
            if (existStaff == null)
            {
                return "Böyle bir staff bulunmamaktadır.";
            }
            else
            {
                return existStaff.ShiftSchedule;
            }
        }

        public void RegisterStaff(Staff staff)
        {
            var existStaff = _staffRepository.GetById(staff.Id);
            if(existStaff != null)
            {
                Console.WriteLine("Kayıt zaten mevcut.");
            }
            else
            {
                _staffRepository.Add(staff);
                Console.WriteLine("Kayıt başarıyla yapıldı.");
            }
        }
    }
}
