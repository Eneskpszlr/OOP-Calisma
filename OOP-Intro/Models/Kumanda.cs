using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Intro.Models
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

    public class Kumanda
    {
        public string MyProperty { get; set; } != null;

        ////Constructor - Yapici metod
        //public Kumanda()
        //{

        //}

        ////Destructor - Yikici Metod
        //~Kumanda()
        //{

        //}




        // prop + tab
        //public int Id { get; set; }
        //public string Marka { get; set; }
        //public string Model { get; set; }
        //public int PilAdedi { get; set; }

        //public Kumanda()
        //{
        //    Console.WriteLine("Kumanda constructor tetiklendi.");
        //}

        //public Kumanda(string marka, string model) : this()
        //{
        //    Marka = marka;
        //    Model = model;
        //    Console.WriteLine($"{Marka} {Model}");
        //}

        //public Kumanda(string marka, string model, int pilAdedi) : this(marka, model)  //Parametreleri doldurur sonra this()'e gider ilk constructoru çalıştıırr sonra tekrar bu constructor içindeki atamaları yapar.
        //{
        //    //this.Marka = marka;    //this mevcut classtaki parametreyi belirtmek içni kullanılır,
        //    //                       //isim çakışması yoksa gereksiz.
        //    //Model = model;
        //    PilAdedi = pilAdedi;
        //    Console.WriteLine(PilAdedi);
        //}

        //public Kumanda()
        //{

        //}
        //public Kumanda(string marka, string model, int pilAdedi)
        //{
        //    if (marka.Length > 7)
        //        this.marka = marka.Remove(7);
        //    else
        //        this.marka = marka;

        //    if (pilAdedi < 1)
        //        this.pilAdedi = 1;
        //    else 
        //        this.pilAdedi = pilAdedi;

        //    this.model = model;
        //}

        //string marka;
        //string model;
        //int pilAdedi;

        //public void MarkaSet(string marka)
        //{
        //    if (marka.Length > 7)
        //        this.marka = marka.Remove(7);
        //    else
        //        this.marka = marka;
        //}
        //public string MarkaGet() => marka;  //  tek satır varsa bu şekilde kısayoldan yazılabilir.

        //public string ModelGet() => model;

        //public void ModelSet(string model)
        //{
        //        this.model = model;
        //}
        ////public string MarkaGet()
        ////{
        ////    return marka;
        ////}

        ////public string ModelGet()
        ////{
        ////    return model;
        ////}
        //public int PilAdediGet()
        //{
        //    return pilAdedi;
        //}

        //public void PilAdediSet(int pilAdedi)
        //{
        //    if (pilAdedi < 1)
        //        this.pilAdedi = 1;
        //    else
        //        this.pilAdedi = pilAdedi;
        //}


        //private string _marka;
        //private int _pilAdedi;


        ////kumanda.Marka = "value" => set çalışır
        ////Console.Write(kumanda.Marka) => get çalışır
        //public string Marka 
        //{ 
        //    get
        //    {   // geriye oluşturulan property(özellik) tipinde değer döndürür.
        //        return _marka;
        //    }
        //    set
        //    {
        //        //Dışarıdan girilen değerleri alır ve atama vb. işlemleri yapar.
        //        if(value.Length > 7)
        //            value = value.Substring(7);
        //        else
        //            _marka = value;   
        //    }
        //}
        //public string Model { get; set; }
        //public int PilAdedi 
        //{ 
        //    get => _pilAdedi;
        //    set//(value)// default olarak value değeri içerir.
        //    {
        //        if(value < 1)
        //            value = 1;
        //        _pilAdedi = value;
        //    } 
        //}

        // Bu alandayken dilediğim gibi değer atamaısnı ve okumasını yapabilirim.
        //Fakat dışarıdan değer ataması yapılamaz sadece okunabilir.
        //  public int Id { get; } = 2;
        public int Id { get; private set; } = 2;
        public int No { get; set; }
    }
}
