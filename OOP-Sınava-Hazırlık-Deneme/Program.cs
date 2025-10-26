namespace OOP_Sınava_Hazırlık_Deneme
{
    public class Program
    {
        static List<Person> people = new List<Person>();
        static void Main(string[] args)
        {
            Console.WriteLine("Hastane Otomasyon sistemi");
            while (true)
            {
                Console.WriteLine("Yapmak istediğiniz işlemi seçiniz.");
                Console.Write("1-Yeni Doktor Ekle.\n2-Yeni Hemşire Ekle.\n3-Yeni Hasta Ekle." +
                    "\n4-Yeni Admin Ekle.\n5-Doktora Hasta Ekle.\n6-Personelleri Listele.\n7-Kaydetme İşlemi.\n8-Çıkış");
                string choose = Console.ReadLine();
                switch (choose)
                {
                    case "1":
                        Console.WriteLine("Eklemek istediğiniz doktorun bilgilerini giriniz:");
                        Console.Write("Doktorun adını giriniz: ");
                        string firstname = Console.ReadLine();
                        Console.Write("\nDoktorun soyadını giriniz: ");
                        string lastname = Console.ReadLine();
                        Console.Write("\nDoktorun emailini giriniz: ");
                        string email = Console.ReadLine();
                        Console.Write("\nDoktorun branşını giriniz: ");
                        string speciliability = Console.ReadLine();
                        Console.Write("\nDoktorun deneyim yılını giriniz: ");
                        int expYear = int.Parse(Console.ReadLine());

                        var doctor1 = new Doctor(firstname, lastname, email, speciliability, expYear);
                        doctor1.Save();
                        people.Add(doctor1);

                        break;
                    case "2":
                        Console.WriteLine("Eklemek istediğiniz Hemşirenin bilgilerini giriniz:");
                        Console.Write("Hemşirenin adını giriniz: ");
                        string firstname1 = Console.ReadLine();
                        Console.Write("\nHemşirenin soyadını giriniz: ");
                        string lastname1 = Console.ReadLine();
                        Console.Write("\nHemşirenin emailini giriniz: ");
                        string email1 = Console.ReadLine();
                        Console.Write("\nHemşirenin departmanını giriniz: ");
                        string department1 = Console.ReadLine();
                        Console.Write("\nHemşirenin shiftini giriniz: ");
                        string shift1 = Console.ReadLine();

                        var nurse1 = new Nurse(firstname1, lastname1, email1, department1, shift1);
                        nurse1.Save();
                        people.Add(nurse1);
                        break;
                    case "3":
                        Console.WriteLine("Eklemek istediğiniz Hastanın bilgilerini giriniz:");
                        Console.Write("Hastanın adını giriniz: ");
                        string firstname2 = Console.ReadLine();
                        Console.Write("\nHastanın soyadını giriniz: ");
                        string lastname2 = Console.ReadLine();
                        Console.Write("\nHastanın emailini giriniz: ");
                        string email2 = Console.ReadLine();
                        Console.Write("\nHastanın Hastalığını giriniz: ");
                        string illness2 = Console.ReadLine();

                        var patient1 = new Patient(firstname2, lastname2, email2, illness2);
                        patient1.Save();
                        people.Add(patient1);
                        break;
                    case "4":
                        Console.WriteLine("Eklemek istediğiniz Adminin bilgilerini giriniz:");
                        Console.Write("\nAdminin adını giriniz: ");
                        string firstname3 = Console.ReadLine();
                        Console.Write("\nAdminin soyadını giriniz: ");
                        string lastname3 = Console.ReadLine();
                        Console.Write("\nAdminin emailini giriniz: ");
                        string email3 = Console.ReadLine();
                        Console.Write("\nHemşirenin departmanını giriniz: ");
                        string department3 = Console.ReadLine();

                        var admin1 = new Admin(firstname3, lastname3, email3, department3);
                        admin1.Save();
                        people.Add(admin1);
                        break;
                    case "5":
                        AssignPatientToDoctor();
                        break;
                    case "6":
                        Console.WriteLine("Personel listesi:");
                        foreach (var p in people)
                            Console.WriteLine($"{p.GetType().Name}: {p}");
                        break;
                    case "7":
                        foreach (var p in people)
                        {
                            if (p is ISaveable s) s.Save();
                        }
                        break;
                    case "8":
                        Console.WriteLine("Çıkış yapılıyor...");
                        return;
                    default:
                        Console.WriteLine("Yanlış tuşlama yaptınız.");
                        break;
                }
            }
        }

        static void AssignPatientToDoctor()
        {
            var doctors = people.OfType<Doctor>().ToList();
            var patients = people.OfType<Patient>().ToList();
            if (!doctors.Any() || !patients.Any())
            {
                Console.WriteLine("Doktor veya hasta yok.");
                return;
            }

            Console.WriteLine("Doktorlar:");
            for (int i = 0; i < doctors.Count; i++)
                Console.WriteLine($"{i}: {doctors[i].FirstName} {doctors[i].LastName}");

            Console.Write("Seçilen doktorun indexi: ");
            if (!int.TryParse(Console.ReadLine(), out int di) || di < 0 || di >= doctors.Count) { Console.WriteLine("Geçersiz"); return; }

            Console.WriteLine("Hastalar:");
            for (int i = 0; i < patients.Count; i++)
                Console.WriteLine($"{i}: {patients[i].FirstName} {patients[i].LastName}");

            Console.Write("Seçilen hastanın indexi: ");
            if (!int.TryParse(Console.ReadLine(), out int pi) || pi < 0 || pi >= patients.Count) { Console.WriteLine("Geçersiz"); return; }

            var doc = doctors[di];
            var pat = patients[pi];
            doc.AddPatient(pat);
            pat.AddAssignedDoctor(doc);
            Console.WriteLine("Hasta doktora atandı.");
        }
    }
}
