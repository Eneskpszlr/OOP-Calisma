using System.Runtime.InteropServices;

namespace OOP_ExampleHakanHoca
{
    internal class Program
    {
        // User(Id,Username,Password,Email,EmailConfirm,FirstName,LastName,CreatedDate)
        // Id : sadece okunabilir olacak. Guid olsun
        // Id : otomatik olacak(artacak). (guid olmadığı durumda)
        // Username boş geçilemez, 3 ile 20 karakter arasında olabilir. eğer fazla olursa kırpılsın eksik kalırsa sol tarafı * sembolüyle doldurulsun.
        // Password en az 8 karakter uzunluğunda olmalıdır. aşağı bir durumda herhangi bir karakterle doldurunuz.
        // Email: boş geçilemez olsun.
        // EmailConfirm : Sadece okunabilir olsun. Email ile aynı değeri döndürsün.
        // FirstName ve LastName : boş geçilemez.

        //Message(Id,Content,SenderId,ReceiverId,CreatedDate)
        // Id : Sadece okunabilir olacak. Tip guid olacak.
        // Content: En az 1 karakter uzunluğunda olmalıdır. aşağı bir durumda herhangi bir karakterle doldurun.
        // SenderId ve ReceiverId : boş geçilemez
        // CreatedDate : sadece okunabilir olsun. Mesajın oluşturulduğu tarihi döndürsün.

        // Generic Repository(CRUD operasyonları içinde bulunsun) yapısı oluşturunuz. Static bir listeyi depo haline getiriniz.
        // Kullanıcı üyelik oluşturur.
        //Kullanıcı giriş yapar.
        // Belirtilen kullanıcı İd veya kullanıcı adı ile mesaj gönderir.
        // Kullanıcı çıkış yapar.
        // Diğer kullanıcı giriş yapıp gelen mesajları görür.
        // Cevap verir.

        static void Main(string[] args)
        {
            var userService = new UserServices();
            var messageService = new MessageServices();

            Console.WriteLine("=== Mini Chat App ===");

            while (true)
            {
                Console.WriteLine("\nSeçenekler:");
                Console.WriteLine("1 - Kayıt Ol");
                Console.WriteLine("2 - Giriş Yap");
                Console.WriteLine("3 - Mesaj Gönder");
                Console.WriteLine("4 - Gelen Kutusunu Gör");
                Console.WriteLine("5 - Kullanıcıları Listele");
                Console.WriteLine("6 - Çıkış Yap");
                Console.WriteLine("0 - Uygulamadan Çık");
                Console.Write("Seçiminiz: ");

                var choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        // Kayıt
                        Console.Write("Kullanıcı adı: ");
                        var username = Console.ReadLine();

                        Console.Write("Ad: ");
                        var firstName = Console.ReadLine();

                        Console.Write("Soyad: ");
                        var lastName = Console.ReadLine();

                        Console.Write("Email: ");
                        var email = Console.ReadLine();

                        Console.Write("Şifre (en az 8 karakter): ");
                        var password = Console.ReadLine();

                        try
                        {
                            var newUser = new User(username, firstName, lastName, email, password);
                            var registerResult = userService.Register(newUser);
                            Console.WriteLine(registerResult);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Kayıt hatası: {ex.Message}");
                        }
                        break;

                    case "2":
                        // Giriş
                        Console.Write("Kullanıcı adı: ");
                        var loginUser = Console.ReadLine();

                        Console.Write("Şifre: ");
                        var loginPass = Console.ReadLine();

                        try
                        {
                            var loginResult = userService.Login(loginUser, loginPass);
                            Console.WriteLine(loginResult);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Giriş hatası: {ex.Message}");
                        }
                        break;

                    case "3":
                        // Mesaj gönder
                        var active = GetActiveSafely(userService);
                        if (active == null)
                        {
                            Console.WriteLine("Önce giriş yapın.");
                            break;
                        }

                        Console.Write("Alıcının Id'sini (Guid) girin: ");
                        var recIdText = Console.ReadLine();
                        if (!Guid.TryParse(recIdText, out Guid receiverId))
                        {
                            Console.WriteLine("Geçersiz Guid formatı.");
                            break;
                        }

                        Console.Write("Mesaj içeriğini girin: ");
                        var content = Console.ReadLine();

                        try
                        {
                            messageService.SendMessage(active.Id, receiverId, content);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Mesaj gönderme hatası: {ex.Message}");
                        }
                        break;

                    case "4":
                        // Gelen kutusu
                        var current = GetActiveSafely(userService);
                        if (current == null)
                        {
                            Console.WriteLine("Önce giriş yapın.");
                            break;
                        }

                        messageService.ReadMessage(current.Id);
                        break;

                    case "5":
                        Console.WriteLine("Kayıtlı kullanıcılar:");
                        try
                        {
                            var all = userService.GetAllUsers();
                            foreach (var u in all)
                                Console.WriteLine($"{u.Username} | Id: {u.Id} | Email: {u.Email}");
                        }
                        catch
                        {
                            Console.WriteLine("GetAllUsers() metodu UserServices içinde yok. Eğer istersen ben ekleyeyim.");
                        }
                        break;

                    case "6":
                        // Çıkış
                        var logged = GetActiveSafely(userService);
                        if (logged == null)
                        {
                            Console.WriteLine("Zaten giriş yapılmamış.");
                            break;
                        }
                        userService.Logout(logged);
                        Console.WriteLine("Çıkış yapıldı.");
                        break;

                    case "0":
                        Console.WriteLine("Uygulamadan çıkılıyor...");
                        return;

                    default:
                        Console.WriteLine("Geçersiz seçim, tekrar deneyin.");
                        break;
                }
            }
        }
        static User GetActiveSafely(dynamic userService)
        {
            try
            {
                return userService.GetActiveUser();
            }
            catch
            {
                return null;
            }
        }
    }
}
