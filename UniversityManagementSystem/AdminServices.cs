using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityManagementSystem
{
    public class AdminServices : IAdminServices
    {
        private readonly IRepository<Admin> _adminRepo;  // Admin verilerini tutan repository
        private readonly IRepository<Teacher> _teacherRepo;  // Teacher verilerini tutan repository

        // Constructor Dependency Injection
        public AdminServices(IRepository<Admin> adminRepo, IRepository<Teacher> teacherRepo)
        {
            _adminRepo = adminRepo;
            _teacherRepo = teacherRepo;
        }
        public void AddTeacher(Guid adminId, Teacher teacher)
        {
            var admin = _adminRepo.GetById(adminId);
            if (admin == null)
            {
                throw new ArgumentNullException("Böyle bir admin bulunmamaktadır.");
            }
            var existTeacher = _teacherRepo.GetById(teacher.Id);
            if (existTeacher == null)
            {
                throw new ArgumentNullException("Böyle bir teacher bulunmamaktadır.");
            }
            else
            {
                _teacherRepo.Add(teacher);
                admin.ManagedTeachers.Add(teacher);
                Console.WriteLine("Öğretmen başarıyla admine atandı.");
            }
        }
        public List<Teacher> ManagedTeachers(Guid adminId)
        {
            var admin = _adminRepo.GetById(adminId);
            if (admin == null)
            {
                throw new ArgumentNullException("Böyle bir admin bulunmamaktadır.");
            }
            return admin.ManagedTeachers;
        }
    }
}
