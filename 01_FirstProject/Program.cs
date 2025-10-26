using System.Security.Cryptography.X509Certificates;

namespace _01_FirstProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region TamSayılar (Integer Types)
            //Byte
            Console.WriteLine(nameof(Byte));
            Console.WriteLine($"Alt Limit: {Byte.MinValue,5}");
            Console.WriteLine($"Üst Limit: {Byte.MaxValue,5}");
            Console.WriteLine($"Boyut    : {sizeof(Byte),5}");

            Console.WriteLine(new string('*', 20));

            //SByte
            Console.WriteLine(nameof(SByte));
            Console.WriteLine($"Alt Limit: {SByte.MinValue,5}");
            Console.WriteLine($"Üst Limit: {SByte.MaxValue,5}");
            Console.WriteLine($"Boyut    : {sizeof(SByte),5}");

            Console.WriteLine(new string('*', 20));

            //Short
            Console.WriteLine(nameof(Int16));
            Console.WriteLine($"Alt Limit: {short.MinValue,5}");
            Console.WriteLine($"Üst Limit: {short.MaxValue,5}");
            Console.WriteLine($"Boyut    : {sizeof(short)}");

            Console.WriteLine(new string('*', 20));

            //UShort
            Console.WriteLine(nameof(UInt16));
            Console.WriteLine($"Alt Limit: {ushort.MinValue,5}");
            Console.WriteLine($"Üst Limit: {ushort.MaxValue,5}");
            Console.WriteLine($"Boyut    : {sizeof(ushort)}");

            Console.WriteLine(new string('*', 20));

            //Int
            Console.WriteLine(nameof(Int32));
            Console.WriteLine($"Alt Limit: {int.MinValue,5}");
            Console.WriteLine($"Üst Limit: {int.MaxValue,5}");
            Console.WriteLine($"Boyut    : {sizeof(int)}");

            Console.WriteLine(new string('*', 20));

            //UInt
            Console.WriteLine(nameof(UInt32));
            Console.WriteLine($"Alt Limit: {uint.MinValue,5}");
            Console.WriteLine($"Üst Limit: {uint.MaxValue,5}");
            Console.WriteLine($"Boyut    : {sizeof(uint)}");

            Console.WriteLine(new string('*', 20));

            //Long
            Console.WriteLine(nameof(Int64));
            Console.WriteLine($"Alt Limit: {long.MinValue,5}");
            Console.WriteLine($"Üst Limit: {long.MaxValue,5}");
            Console.WriteLine($"Boyut    : {sizeof(long)}");

            Console.WriteLine(new string('*', 20));

            //ULong
            Console.WriteLine(nameof(UInt64));
            Console.WriteLine($"Alt Limit: {ulong.MinValue,5}");
            Console.WriteLine($"Üst Limit: {ulong.MaxValue,5}");
            Console.WriteLine($"Boyut    : {sizeof(ulong)}");

            Console.WriteLine(new string('*', 20));
            #endregion

            #region OndalikliSayilar (Floating Point Types)

            //Float
            Console.WriteLine(nameof(Single));
            Console.WriteLine($"Alt Limit: {float.MinValue,5}");
            Console.WriteLine($"Üst Limit: {float.MaxValue,5}");
            Console.WriteLine($"Boyut: {sizeof(float),5}");
            //1,23456789 => 1,2345678

            Console.WriteLine(new string('*', 20));

            Console.WriteLine(nameof(Double));
            Console.WriteLine($"Alt Limit: {double.MinValue,5}");
            Console.WriteLine($"Üst Limit: {double.MaxValue,5}");
            Console.WriteLine($"Boyut: {sizeof(double),5}");

            Console.WriteLine(new string('*', 20));

            Console.WriteLine(nameof(Decimal));
            Console.WriteLine($"Alt Limit: {decimal.MinValue,5}");
            Console.WriteLine($"Üst Limit: {decimal.MaxValue,5}");
            Console.WriteLine($"Boyut: {sizeof(decimal),5}");

            Console.WriteLine(new string('*', 20));
            #endregion

            #region Karakterler
            Console.WriteLine(nameof(Char));
            Console.WriteLine($"Limit: 1");
            Console.WriteLine($"Boyut: {sizeof(char)}");

            Console.WriteLine(new string('*', 20));

            Console.WriteLine(nameof(String));
            Console.WriteLine($"Limit: 1");
            #endregion

            #region Booleans (Boolean Type)
            Console.WriteLine(nameof(Boolean));
            Console.WriteLine($"Alt Limit: {false}");
            Console.WriteLine($"Üst Limit: {true}");
            Console.WriteLine($"Boyut: {1}");

            Console.WriteLine(new string('*', 20));
            #endregion

            #region DegiskenTanımlama
            //veri_tipi degisken_adi = deger;

            //int age=40, score;

            //age = 0;
            //score = 0;

            //int x = 5;

            //if (true)
            //{
            //    Console.WriteLine(x);
            //    int y = 10;
            //}

            //int X=10;
            //int x=5;

            //int getScore;

            //void CalculateScore()
            //{ 

            //}

            //int numberOne = 268;
            //double number = 2.4;

            //Byte deneme = 2;
            //int deneme1 = 2;

            //float ondalik1 = 2.5F;
            //double ondalik2 = 2.5D;
            //decimal ondalik3 = 2.5M;

            //int sayiX;
            //double sayiY;
            //char charZ;
            //bool boolQ;
            //string strW = "Merhaba Dünya";
            //Console.WriteLine(strW.GetHashCode());
            //Console.WriteLine(strW);
            //strW = "Merhaba Dünya2";
            //Console.WriteLine(strW.GetHashCode());
            //Console.WriteLine(strW);
            //Console.ReadLine();

            //int int1 = 5;
            //int int2 = int1;

            //string str1 = "Merhaba";
            //string str2 = str1;

            //Değişmezlik Immutability
            //string text = "Fatih";
            //Console.WriteLine("Başlangıç: " + text);

            //text += " Alkan";
            //Console.WriteLine("Değişilik Sonrası: " + text);

            //string orginal = "Fatih";

            //Console.WriteLine(Object.ReferenceEquals(text,orginal));
            #endregion

            #region GelişmişVeriTipleri

            Object deger1 = 1;
            Object deger2 = 2.5;
            Object deger3 = "Merhaba";
            Object deger4 = true;

            //int sayi1 = 5;
            //Console.WriteLine(deger1*2);

            //Boxing: ilkel veri tipini object'e atamaya
            //Unboxing: Object'en ilkel veri tipine dönüştürme.

            Console.WriteLine((int)deger1 * 2);

            //Derleme Zamanı (Compilte Time) - Çalışma Zamanı (Run Time)

            //Derleme Zamanında tip ataması yapılır.
            var degisken1 = 5;
            var degisken2 = 5.4;
            var degisken3 = "Merhaba";
            var degisken4 = true;

            Console.WriteLine(degisken2 * 2);

            //Çalışma zamanında tip ataması yapılır.
            dynamic deneme1 = 5;
            dynamic deneme2 = 6.5;
            dynamic deneme3 = "Merhaba";
            dynamic deneme4 = true;

            Console.WriteLine(deneme1 * 2);

            #endregion

            #region Nullable Tipler

            int? nullableSayi = null; //Bu değişken int tipindedir. Ama null geçilebilir.

            Console.WriteLine(nullableSayi);
            Console.WriteLine(nullableSayi.HasValue);

            nullableSayi = 25;

            Console.WriteLine(nullableSayi.HasValue);
            Console.WriteLine(nullableSayi);

            int deneme = nullableSayi.Value * 5;

            int? puan = null;
            int sonuc = puan ?? 50;
            Console.WriteLine(sonuc);

            #endregion
        }
    }
}