using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityManagementSystem
{
    public class TeacherServices : ITeacherServices
    {
        private readonly IRepository<Teacher> _teacherRepo; // Teacher repository
        private readonly IRepository<Course> _courseRepo;   // Course repository

        public TeacherServices(IRepository<Teacher> teacherRepo, IRepository<Course> courseRepo)
        {
            _teacherRepo = teacherRepo;
            _courseRepo = courseRepo;
        }
        public void AssignCourse(Guid teacherId, Guid courseId)
        {
            var teacher = _teacherRepo.GetById(teacherId);
            var course = _courseRepo.GetById(courseId);
            if(teacher == null || course == null)
            {
                throw new Exception("Öğretmen veya ders bulunmamaktadır. Bilgileri tekrar gözden geçirin.");
            }
            else if(!teacher.GivenCourses.Contains(course))
            {
                teacher.GivenCourses.Add(course);
                Console.WriteLine("Ders başarıyla atandı.");
            }
            else
            {
                Console.WriteLine("Bu öğretmen zaten bu dersi veriyor.");
            }
        }
        public void RegisterTeacher(Teacher teacher)
        {
            if (teacher == null) 
                throw new ArgumentNullException("Teacher bilgileri boş olamaz.");
            var existingTeacher = _teacherRepo.GetAll().FirstOrDefault(x => x.Id == teacher.Id);
            if (existingTeacher != null)
                throw new Exception("Bu öğretmen zaten kayıtlı.");
            else
            {
                _teacherRepo.Add(teacher);
                Console.WriteLine("Öğretmen başarıyla kaydedildi.");
            }
        }
        public List<Course> GetTeacherCourses(Guid teacherId)
        {
            var teacher = _teacherRepo.GetById(teacherId);
            if (teacher == null)
            {
                throw new Exception("Öğretmen bulunmamaktadır. Bilgileri tekrar gözden geçirin.");
            }
            return teacher.GivenCourses;
        }
    }
}
