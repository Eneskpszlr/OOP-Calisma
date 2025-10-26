using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem
{
    public class ManagerService : IManagerService
    {
        private readonly IRepository<Manager> _managerRepository;
        private readonly IRepository<Staff> _staffRepository;

        public ManagerService(IRepository<Manager> managerRepository, IRepository<Staff> staffRepository)
        {
            _managerRepository = managerRepository;
            _staffRepository = staffRepository;
        }
        public void AssignStaffToManager(Guid managerId, Guid staffId)
        {
            var existManager = _managerRepository.GetById(managerId);
            if (existManager == null)
            {
                Console.WriteLine("Böyle bir yönetici bulunmamaktadır.");
                return;
            }
            var existStaff = _staffRepository.GetById(staffId);
            if(existStaff == null)
            {
                Console.WriteLine("Böyle bir staff bulunmamaktadır.");
                return;
            }
            if (existManager.ManagedStaff == null)
            {
                existManager.ManagedStaff = new List<Staff>(); // Initialize if null
            }

            existManager.ManagedStaff.Add(existStaff); // Add staff to manager's list
            Console.WriteLine("Staff başarıyla yöneticisine atandı.");
        }

        public void GetManagerStaff(Guid managerId)
        {
            var existManager = _managerRepository.GetById(managerId);
            if (existManager == null)
            {
                Console.WriteLine("Böyle bir yönetici bulunmamaktadır");
                return;
            }
            if (existManager.ManagedStaff == null || existManager.ManagedStaff.Count == 0)
            {
                Console.WriteLine("Yöneticiye bağlı bir staff bulunmamaktadır.");
            }
            else
            {
                Console.WriteLine("Yöneticinin altındaki stafflar:");
                foreach (var staff in existManager.ManagedStaff)
                {
                    Console.WriteLine(staff.ToString());
                }
            }
        }
    }
}
