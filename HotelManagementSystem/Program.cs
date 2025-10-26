namespace HotelManagementSystem
{
    internal class Program
    {
        private static readonly IRepository<Customer> _customerRepository = new Repository<Customer>();
        private static readonly IRepository<Staff> _staffRepository = new Repository<Staff>();
        private static readonly IRepository<Manager> _managerRepository = new Repository<Manager>();
        private static readonly IRepository<Room> _roomRepository = new Repository<Room>();
        private static readonly IRepository<Reservation> _reservationRepository = new Repository<Reservation>();

        private static ICustomerService _customerService = new CustomerService(_customerRepository, _reservationRepository, _roomRepository);
        private static IStaffService _staffService = new StaffService(_staffRepository);
        private static IManagerService _managerService = new ManagerService(_managerRepository, _staffRepository);
        private static IReservationService _reservationService = new ReservationService(_reservationRepository, _roomRepository);

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("==== HOTEL MANAGEMENT SYSTEM ====");
                Console.WriteLine("1- Müşteri Kaydı");
                Console.WriteLine("2- Staff Kaydı");
                Console.WriteLine("3- Yönetici Atama");
                Console.WriteLine("4- Create Reservation");
                Console.WriteLine("5- GetAvailableRooms");
                Console.WriteLine("6- Cancel Reservation");
                Console.WriteLine("7- Çalışan Listesi ve Görevler");
                Console.WriteLine("8- Yöneticiye bağlı Çalışanlar");
                Console.WriteLine("9- Çıkış");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        RegisterCustomer();
                        break;
                    case "2":
                        RegisterStaff();
                        break;
                    case "3":
                        AssignStaffToManager();
                        break;
                    case "4":
                        CreateReservation();
                        break;
                    case "5":
                        GetAvailableRooms();
                        break;
                    case "6":
                        CancelReservation();
                        break;
                    case "7":
                        GetStaffList();
                        break;
                    case "8":
                        GetManagerStaff();
                        break;
                    case "9":
                        Console.WriteLine("Çıkış yapılıyor...");
                        return;
                    default:
                        Console.WriteLine("Geçersiz seçim, tekrar deneyin.");
                        break;
                }
            }
        }
        public static void RegisterCustomer()
        {
            Console.WriteLine("==== Müşteri Kaydı ====");
            Console.Write("Ad: ");
            string firstName = Console.ReadLine();
            Console.Write("Soyad: ");
            string lastName = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();

            var result = _customerService.RegisterCustomer(new Customer(firstName, lastName, email));
            Console.WriteLine(result);
        }

        public static void RegisterStaff()
        {
            Console.WriteLine("==== Staff Kaydı ====");
            Console.Write("Ad: ");
            string firstName = Console.ReadLine();
            Console.Write("Soyad: ");
            string lastName = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.WriteLine("Rolünü seçiniz: 1-Recepcionist 2-Cleaner 3-Manager");
            int roleChoice = int.Parse(Console.ReadLine());
            RoleStatus role;

            // Enum dönüştürme (Sayısal değeri RoleStatus enum'una çeviriyoruz)
            switch (roleChoice)
            {
                case 1:
                    role = RoleStatus.Recepcionist;
                    break;
                case 2:
                    role = RoleStatus.Cleaner;
                    break;
                case 3:
                    role = RoleStatus.Manager;
                    break;
                default:
                    Console.WriteLine("Geçersiz seçim yapıldı. Varsayılan olarak Recepcionist olarak kabul ediliyor.");
                    role = RoleStatus.Recepcionist;
                    break;
            }

            Console.Write("Deneyim yılını giriniz");
            int expYear = int.Parse(Console.ReadLine());
            Console.Write("Shift bilgisini giriniz:");
            string shift = Console.ReadLine();

            var staff = new Staff(firstName, lastName, email, role, expYear, shift);  
            _staffService.RegisterStaff(staff);
        }
        public static void AssignStaffToManager()
        {
            Console.WriteLine("=== Yöneticiye çalışan atama ===");
            Console.Write("Manager Id'yi giriniz.");
            Guid managerId = Guid.Parse(Console.ReadLine());
            Console.Write("Staff Id'yi giriniz.");
            Guid staffId = Guid.Parse(Console.ReadLine());

            _managerService.AssignStaffToManager(managerId, staffId);
        }

        public static void CreateReservation()
        {
            Console.WriteLine("=== Rezervasyon Oluşturma ===");
            Console.Write("Customer Id'yi giriniz.");
            Guid customerId = Guid.Parse(Console.ReadLine());
            Console.Write("Room Id'yi giriniz.");
            Guid roomId = Guid.Parse(Console.ReadLine());
            Console.Write("Rezervasyon başlangıç tarihini giriniz.");
            DateTime StartDate = DateTime.Parse(Console.ReadLine());
            Console.Write("Rezervasyon bitiş tarihini giriniz.");
            DateTime EndDate = DateTime.Parse(Console.ReadLine());

            _customerService.CreateReservation(customerId, roomId, StartDate, EndDate);
        }

        public static void GetAvailableRooms()
        {
            Console.WriteLine("=== Boş Oda Listesi ===");
            var availableRooms = _roomRepository.GetAll().Where(r => r.IsAvailable).ToList();

            if (availableRooms.Count == 0)
            {
                Console.WriteLine("Boş oda bulunmamaktadır.");
            }
            else
            {
                foreach (var room in availableRooms)
                {
                    Console.WriteLine($"Oda ID: {room.RoomId}, Oda Türü: {room.RoomType}, Fiyat: {room.Price}");
                }
            }
        }

        public static void CancelReservation()
        {
            Console.WriteLine("=== Rezervasyon İptal Etme ===");
            Console.Write("Rezervasyon Id'sini giriniz");
            Guid id = Guid.Parse(Console.ReadLine());
            
            _reservationService.CancelReservation(id);
        }

        public static void GetStaffList()
        {
            Console.WriteLine("=== Çalışan Listesi ve Görevler ===");
            var staffList = _staffRepository.GetAll();

            if (staffList.Count == 0)
            {
                Console.WriteLine("Çalışan bulunmamaktadır.");
            }
            else
            {
                foreach (var staff in staffList)
                {
                    Console.WriteLine($"Adı: {staff.FirstName} {staff.LastName}, Rolü: {staff.Role}, Çalışma Saatleri: {staff.ShiftSchedule}");
                }
            }
        }

        public static void GetManagerStaff()
        {
            Console.WriteLine("=== Yöneticiye Bağlı Çalışanlar ===");
            Console.Write("Yönetici Id'sini giriniz:");
            Guid id = Guid.Parse(Console.ReadLine());

            _managerService.GetManagerStaff(id);
        }
    }
}

//public static void GetStudentList()
//{
//    var students = _studentRepository.GetAll();
//    foreach (var student in students)
//    {
//        Console.WriteLine(student.ToString());
//    }
//}

