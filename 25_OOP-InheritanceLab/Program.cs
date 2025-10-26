using _25_OOP_InheritanceLab;

List<Person> person = new List<Person>()
        {
            new Teacher("Fatih", "Alkan", "@gmail.com", "Yazılım", 13),
            new Teacher("Mehmet", "Yıldız", "@gmail.com", ".Net", 8),
            new Student("Hüseyin", "Çetin", "@gmail.com", 222),
            new Student("Enes", "Kapsızlar", "@gmail.com", 366),
            new Student("Berkay", "Uslu", "@gmail.com", 421),
            new Student("Melih", "İlhan", "@gmail.com", 257),
            new Manager("Berkay", "Uslu", "@gmail.com", Role.MüdürYardımcısı),
            new Manager("Melih", "İlhan", "@gmail.com", Role.Müdür),
        };

Manager.IliskileriKur(person);
//Öğrenci Otomasyon Sistemi
/* Öğrenci => OgrenciNo, Notlar(list<int>), Ortalama Hesaplama()
 * Öğretmen => Branşı, DeneyimYılı
 * Yönetici => Role, YönettiğiKişiler 
 * 
 * Id (Otomatik Öğrenciler=100, Öğretmenler=300, Yöneticiler=600), Ad, Soyad, Email, ToString()
 * 
 * Console UI (Listeleme ve Ekleme)
 */

Console.WriteLine("Öğrenci Otomasyon Sistemi\n");
while (true)
{
    Console.WriteLine("Yapmak istediğiniz işlemi seçiniz: \n");
    Console.WriteLine("1-Personelleri Listele.");
    Console.WriteLine("2-Personel Ekle.");
    Console.WriteLine("3-Çıkış");
    int choose = int.Parse(Console.ReadLine());
    switch (choose)
    {
        case 1:
            Console.WriteLine("Personel Listesi: \n");
            foreach (Person item in person)
            {
                Console.WriteLine(item);
            }
            break;
        case 2:
            Console.WriteLine("Eklemek istediğiniz personel türünü seçiniz: ");
            Console.WriteLine("1-Öğrenci");
            Console.WriteLine("2-Öğretmen");
            Console.WriteLine("3-Yönetici");
            int choose2 = int.Parse(Console.ReadLine());
            switch (choose2)
            {
                case 1:
                    Console.WriteLine("Eklemek istediğiniz öğrenci bilgilerini giriniz: ");
                    Console.WriteLine("İsmini giriniz: ");
                    string firstname = Console.ReadLine();
                    Console.WriteLine("Soyismini giriniz: ");
                    string lastname = Console.ReadLine();
                    Console.WriteLine("emaili giriniz: ");
                    string email = Console.ReadLine();
                    Console.WriteLine("Öğrenci numarasını giriniz: ");
                    int no = int.Parse(Console.ReadLine());

                    person.Add(new Student(firstname, lastname, email, no));

                    Console.WriteLine("Öğrenci başarıyla eklendi.");

                    break;
                case 2:
                    Console.WriteLine("Eklemek istediğiniz öğretmen bilgilerini giriniz: ");
                    Console.WriteLine("İsmini giriniz: ");
                    string firstname1 = Console.ReadLine();
                    Console.WriteLine("Soyismini giriniz: ");
                    string lastname1 = Console.ReadLine();
                    Console.WriteLine("emaili giriniz: ");
                    string email1 = Console.ReadLine();
                    Console.WriteLine("Branşını giriniz: ");
                    string branch1 = Console.ReadLine();
                    Console.WriteLine("Deneyim yılını giriniz: ");
                    int no1 = int.Parse(Console.ReadLine());

                    person.Add(new Teacher(firstname1, lastname1, email1, branch1, no1));

                    Console.WriteLine("Öğretmen başarıyla eklendi.");
                    break;
                case 3:
                    Console.WriteLine("Eklemek istediğiniz Yönetici bilgilerini giriniz: ");
                    Console.WriteLine("İsmini giriniz: ");
                    string firstname2 = Console.ReadLine();
                    Console.WriteLine("Soyismini giriniz: ");
                    string lastname2 = Console.ReadLine();
                    Console.WriteLine("emaili giriniz: ");
                    string email2 = Console.ReadLine();
                    Console.WriteLine("Pozisyon bilgisini giriniz (Müdür / MüdürYardımcısı): ");
                    string role = Console.ReadLine();

                    if (Enum.TryParse(role, true, out Role role2))
                    {
                        person.Add(new Manager(firstname2, lastname2, email2, role2));
                        Console.WriteLine("Yönetici başarıyla eklendi.");
                    }
                    else
                    {
                        Console.WriteLine("Geçersiz rol girdiniz. Sadece 'Müdür' veya 'MüdürYardımcısı' yazınız.");
                    }
                    break;
                default:
                    Console.WriteLine("Yanlış tuşlama yaptınız.");
                    break;
            }
            break;
        case 3:
            Console.WriteLine("Çıkış yapılıyor...");
            return;
        default:
            Console.WriteLine("Yanlış tuşlama yaptınız.");
            break;
    }
}
