using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityManagementSystem
{
    public class StudentServices : IStudentServices
    {
        private readonly IRepository<Student> _studentRepository;
        private readonly IRepository<Course> _courseRepository;

        public StudentServices(IRepository<Student> studentRepository, IRepository<Course> courseRepository)
        {
            _studentRepository = studentRepository;
            _courseRepository = courseRepository;
        }

        public List<Student> GetAllStudents()
        {
            return _studentRepository.GetAll();
        }
        public List<Course> GetStudentCourses(Guid studentId)
        {
            var student = _studentRepository.GetById(studentId);
            if (student == null)
            {
                throw new ArgumentNullException("Böyle bir öğrenci bulunmamaktadır.");
            }
            return student.ToCourseList;
        }
        public string RegisterStudent(Student student)
        {
            var existing = _studentRepository.GetAll().FirstOrDefault(x => ((dynamic)x).Id == student.Id);
            if (existing != null) {
                throw new InvalidOperationException("Bu öğrenci zaten kayıtlı");
            }
            else
            {
                _studentRepository.Add(student);
                return "Öğrenci Kaydı başarıyla tamamlandı.";
            }     
        }
        public string RegStudentToCourse(Guid studentId, Guid courseId)
        {
            var course = _courseRepository.GetById(courseId);
            if (course == null) 
            {
                throw new InvalidOperationException("Ders kaydı bulunamadı.");
            }
            var student = _studentRepository.GetById(studentId);
            if (student == null)
            {
                throw new InvalidOperationException("Öğrenci kaydı bulunamadı.");
            }
            if (student.ToCourseList.Any(c => ((dynamic)c).CourseCode == courseId))
            {
                throw new InvalidOperationException("Öğrenci zaten bu derse kayıtlı.");
            }
            student.ToCourseList.Add(course);
            return $"Başarıyla {course.CourseName} dersine kaydoldunuz.";
        }

        // Öğrenci girişini yapar (login)
        public Student LoginStudent(string email)
        {
            // E-posta adresine göre öğrenci kontrolü
            var student = _studentRepository.GetAll().FirstOrDefault(x => x.Email == email);
            return student;
        }
    }
}
