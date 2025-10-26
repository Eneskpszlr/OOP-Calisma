using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityManagementSystem
{
    public class CourseServices : ICourseServices
    {
        private readonly IRepository<Course> _courseRepository;
        public CourseServices(IRepository<Course> courseRepository)
        {
            _courseRepository = courseRepository;
        }
        public string CreateCourse(Course course)
        {
            if (course == null) 
                throw new ArgumentNullException("Course bilgileri boş olamaz");
            var existing = _courseRepository.GetById(course.CourseCode);
            if (existing != null)
            {
                return "Ders zaten mevcut.";
            }
            else
            {
                _courseRepository.Add(course);
                return "Ders başarıyla oluşturuldu.";
            }
        }
        public List<Course> GetAllCourses()
        {
            return _courseRepository.GetAll();
        }
        public string GetCourseDetails(Guid courseId)
        {
            var course = _courseRepository.GetById(courseId);
            if (course == null)
            {
                throw new ArgumentException("Böyle bir ders bulunmamaktadır.");
            }
            else
            {
                return course.ToString();   
            }
        }
    }
}
