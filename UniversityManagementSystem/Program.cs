namespace UniversityManagementSystem
{
    internal class Program
    {
        // Dependency Injection ile servisleri başlatıyoruz
        private static readonly IRepository<Student> _studentRepository = new Repository<Student>(); // Öğrenci repository
        private static readonly IRepository<Course> _courseRepository = new Repository<Course>();   // Ders repository
        private static readonly IRepository<Teacher> _teacherRepository = new Repository<Teacher>(); // Öğretmen repository
        private static readonly IRepository<Admin> _adminRepository = new Repository<Admin>(); // Admin repository

        private static IStudentServices _studentService = new StudentServices(_studentRepository, _courseRepository);
        private static ICourseServices _courseService = new CourseServices(_courseRepository);
        private static ITeacherServices _teacherService = new TeacherServices(_teacherRepository, _courseRepository);
        private static IAdminServices _adminService = new AdminServices(_adminRepository, _teacherRepository);

        private static Student currentStudent = null;

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("==== UNIVERSITY MANAGEMENT SYSTEM ====");
                Console.WriteLine("1- Öğrenci Kaydı");
                Console.WriteLine("2- Öğrenci Girişi");
                Console.WriteLine("3- Derse Kaydol");
                Console.WriteLine("4- Öğrencinin Derslerini Görüntüle");
                Console.WriteLine("5- Öğretmen Atama ve Ders Verme");
                Console.WriteLine("6- Ders Listeleme ve Detaylı Görüntüleme");
                Console.WriteLine("7- Öğrencileri Listele");
                Console.WriteLine("8- Öğretmen Kaydı");
                Console.WriteLine("9- Öğretmenin Verdiği Dersler");
                Console.WriteLine("10- Dersin Öğrencilerini Listeleme");
                Console.WriteLine("11- Öğrenci Kayıtlı Dersini Çıkarma");
                Console.WriteLine("12- Öğretmene Ders Atama");
                Console.WriteLine("13- Admin'e Öğretmen Atama");
                Console.WriteLine("14- Admin Yönetimindeki Öğretmenleri Listele");
                Console.WriteLine("15- Çıkış");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        RegisterStudent();
                        break;
                    case "2":
                        LoginStudent();
                        break;
                    case "3":
                        EnrollToCourse();
                        break;
                    case "4":
                        ViewStudentCourses();
                        break;
                    case "5":
                        AssignTeacherToCourse();
                        break;
                    case "6":
                        ListCourses();
                        break;
                    case "7":
                        GetStudentList();
                        break;
                    case "8":
                        RegisterTeacher();
                        break;
                    case "9":
                        GetTeacherCourses();
                        break;
                    case "10":
                        Console.WriteLine("Geçici olarak kaldırıldı.");
                        //GetStudentsInCourse();
                        break;
                    case "11":
                        Console.WriteLine("Geçici olarak kaldırıldı.");
                        //UnenrollFromCourse(); 
                        break;
                    case "12":
                        AssignCourseToTeacher();
                        break;
                    case "13":
                        AssignTeacherToAdmin();
                        break;
                    case "14":
                        ListTeachersManagedByAdmin();
                        break;
                    case "15":
                        Console.WriteLine("Çıkış yapılıyor...");
                        return;
                    default:
                        Console.WriteLine("Geçersiz seçim, tekrar deneyin.");
                        break;
                }
            }
        }

        // Öğrenci kaydı
        public static void RegisterStudent()
        {
            Console.WriteLine("==== Öğrenci Kaydı ====");
            Console.Write("Ad: ");
            string firstName = Console.ReadLine();
            Console.Write("Soyad: ");
            string lastName = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();

            var result = _studentService.RegisterStudent(new Student(firstName, lastName, email));
            Console.WriteLine(result);
        }

        // Öğrenci girişi
        public static void LoginStudent()
        {
            Console.WriteLine("==== Öğrenci Girişi ====");
            Console.Write("Email: ");
            string email = Console.ReadLine();

            currentStudent = _studentService.LoginStudent(email);

            if (currentStudent != null)
            {
                Console.WriteLine($"Hoşgeldiniz, {currentStudent.FirstName} {currentStudent.LastName}!");
            }
            else
            {
                Console.WriteLine("Öğrenci bulunamadı. Lütfen önce kaydolun.");
            }
        }

        // Derse kaydolma
        public static void EnrollToCourse()
        {
            if (currentStudent == null)
            {
                Console.WriteLine("Öncelikle giriş yapmanız gerekmektedir.");
                return;
            }

            Console.WriteLine("==== Derse Kaydol ====");
            var courses = _courseService.GetAllCourses();

            Console.WriteLine("Kayıtlı dersler:");
            foreach (var course in courses)
            {
                Console.WriteLine($"{course.CourseName} - Öğretmen ID: {course.TeacherId}");
            }

            Console.Write("Bir ders seçin (Ders ID'sini girin): ");
            Guid courseId = Guid.Parse(Console.ReadLine());

            var result = _studentService.RegStudentToCourse(currentStudent.Id, courseId);
            Console.WriteLine(result);
        }

        // Öğrencinin derslerini görüntüleme
        public static void ViewStudentCourses()
        {
            if (currentStudent == null)
            {
                Console.WriteLine("Öncelikle giriş yapmanız gerekmektedir.");
                return;
            }

            var courses = _studentService.GetStudentCourses(currentStudent.Id);
            Console.WriteLine("==== Öğrencinin Dersleri ====");
            foreach (var course in courses)
            {
                Console.WriteLine(course.CourseName);
            }
        }

        // Öğrencileri Listeleme
        public static void GetStudentList()
        {
            Console.WriteLine("=== Öğrenci Listesi ===");
            var students = _studentService.GetAllStudents();
            if (students.Count == 0)
            {
                Console.WriteLine("Öğrenci kaydı bulunmamaktadır.");
            }
            else
            {
                foreach (var student in students)
                {
                    Console.WriteLine(student);
                }
            }
        }

        // Öğretmen kaydı
        public static void RegisterTeacher()
        {
            Console.WriteLine("==== Öğretmen Kaydı ====");
            Console.Write("Ad: ");
            string firstName = Console.ReadLine();
            Console.Write("Soyad: ");
            string lastName = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Departman: ");
            string department = Console.ReadLine();
            Console.Write("Deneyim Yılı: ");
            int experienceYear = int.Parse(Console.ReadLine());

            var teacher = new Teacher(firstName, lastName, email, department, experienceYear);
            _teacherService.RegisterTeacher(teacher);
        }

        // Öğretmenin verdiği dersler
        public static void GetTeacherCourses()
        {
            Console.WriteLine("==== Öğretmenin Verdiği Dersler ====");
            Console.Write("Öğretmen ID (Guid): ");
            Guid teacherId = Guid.Parse(Console.ReadLine());

            var courses = _teacherService.GetTeacherCourses(teacherId);
            if (courses.Count == 0)
            {
                Console.WriteLine("Bu öğretmenin verdiği ders yok.");
            }
            else
            {
                foreach (var course in courses)
                {
                    Console.WriteLine(course.CourseName);
                }
            }
        }

        //// Dersin öğrencilerini listeleme
        //public static void GetStudentsInCourse()
        //{
        //    Console.WriteLine("==== Dersin Öğrencilerini Listeleme ====");
        //    Console.Write("Ders ID (Guid): ");
        //    Guid courseId = Guid.Parse(Console.ReadLine());

        //    // Dersin bilgilerini al
        //    var course = _courseService.GetCourseDetails(courseId);

        //    // Eğer ders bulunamazsa
        //    if (course == null)
        //    {
        //        Console.WriteLine("Ders bulunamadı.");
        //        return;
        //    }

        //    // Dersin öğrencilerini listele
        //    if (course.RegisteredStudents.Count == 0)
        //    {
        //        Console.WriteLine("Bu derse kaydolmuş öğrenci yok.");
        //    }
        //    else
        //    {
        //        Console.WriteLine("Dersin öğrencileri:");
        //        foreach (var student in course.RegisteredStudents)
        //        {
        //            Console.WriteLine($"{student.FirstName} {student.LastName}");
        //        }
        //    }
        //}

        //// Öğrenci kaydını dersten çıkarma
        //public static void UnenrollFromCourse()
        //{
        //    Console.WriteLine("==== Dersten Çıkarma ====");
        //    Console.Write("Ders ID (Guid): ");
        //    Guid courseId = Guid.Parse(Console.ReadLine());

        //    var result = _studentService.RemoveStudentFromCourse(currentStudent.Id, courseId);
        //    Console.WriteLine(result);
        //}

        // Öğretmene ders atama

        public static void AssignTeacherToCourse()
        {
            Console.WriteLine("==== Öğretmen Atama ve Ders Verme ====");
            Console.Write("Öğretmen ID (Guid): ");
            Guid teacherId = Guid.Parse(Console.ReadLine());

            Console.Write("Ders adı: ");
            string courseName = Console.ReadLine();

            var result = _courseService.CreateCourse(new RegularCourse(courseName, teacherId));
            Console.WriteLine(result);
        }

        public static void AssignCourseToTeacher()
        {
            Console.WriteLine("==== Öğretmene Ders Atama ====");
            Console.Write("Öğretmen ID (Guid): ");
            Guid teacherId = Guid.Parse(Console.ReadLine());

            Console.Write("Ders ID (Guid): ");
            Guid courseId = Guid.Parse(Console.ReadLine());

            _teacherService.AssignCourse(teacherId, courseId);
        }

        // Admin'e öğretmen atama
        public static void AssignTeacherToAdmin()
        {
            Console.WriteLine("==== Admin'e Öğretmen Atama ====");
            Console.Write("Admin ID (Guid): ");
            Guid adminId = Guid.Parse(Console.ReadLine());

            Console.Write("Öğretmen ID (Guid): ");
            Guid teacherId = Guid.Parse(Console.ReadLine());

            _adminService.AddTeacher(adminId, new Teacher("John", "Doe", "john.doe@mail.com", "Math", 5));
        }

        // Admin'in yönettiği öğretmenleri listeleme
        public static void ListTeachersManagedByAdmin()
        {
            Console.WriteLine("==== Admin'in Yönettiği Öğretmenler ====");
            Console.Write("Admin ID (Guid): ");
            Guid adminId = Guid.Parse(Console.ReadLine());

            var teachers = _adminService.ManagedTeachers(adminId);
            foreach (var teacher in teachers)
            {
                Console.WriteLine(teacher);
            }
        }

        // Ders listeleme
        public static void ListCourses()
        {
            var courses = _courseService.GetAllCourses();
            Console.WriteLine("==== Tüm Dersler ====");
            foreach (var course in courses)
            {
                Console.WriteLine(course.CourseName);
            }
        }
    }
}