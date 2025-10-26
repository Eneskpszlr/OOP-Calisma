using OOP_Intro.Models;

namespace OOP_Intro
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region örnek
            //Kumanda kumanda = new();
            //kumanda.Marka = "Samsung";
            //kumanda.Model = "X6";
            //kumanda.PilAdedi = -5;

            //if (kumanda.Marka.Length > 7)
            //    kumanda.Marka = kumanda.Marka.Remove(7);

            //Console.WriteLine(kumanda.Marka);
            //Console.WriteLine(kumanda.Model);

            //if (kumanda.PilAdedi < 1)
            //    kumanda.PilAdedi = 1;

            //Console.WriteLine(kumanda.PilAdedi);

            //Console.WriteLine("Kumanda2");
            //Kumanda kumanda2 = new()
            //{
            //    Model = "LG M1",
            //    Marka = "LG",
            //    PilAdedi = 2
            //};

            //if (kumanda2.Marka.Length > 7)
            //    kumanda2.Marka = kumanda2.Marka.Remove(7);

            //Console.WriteLine(kumanda2.Marka);
            //Console.WriteLine(kumanda2.Model);

            //if (kumanda2.PilAdedi < 1)
            //    kumanda2.PilAdedi = 1;

            //Console.WriteLine(kumanda2.PilAdedi);
            #endregion

            //var k1 = new Kumanda();
            //Console.WriteLine($"k1 : {k1.Marka}");

            //var k2 = new Kumanda( model: "");

            //Not: bir sınıf sadece bir tane constructor üzerinden ayağa kalkabilir.
            //Fakat istenirse ayağa kaldırılan constructor üzerinden diğer constructorlar da tetiklenebilir.
            // var k2 = new Kumanda("Samsung", "17 Pro Max", 2);

            //Kumanda k3 = new Kumanda("Samsunggggg" , "J7", -2);
            ////Console.WriteLine(k3.Marka);
            ////Console.WriteLine(k3.Model);
            ////Console.WriteLine(k3.PilAdedi);

            ////k3.Marka = "Arcelikkkkkk";
            ////Console.WriteLine(k3.Marka);

            //Console.WriteLine(k3.MarkaGet());
            //Console.WriteLine(k3.ModelGet());
            //Console.WriteLine(k3.PilAdediGet());

            //Console.Clear();

            //var k4 = new Kumanda();
            //k4.MarkaSet("Ballalalala");
            //k4.ModelSet("B7");
            //k4.PilAdediSet(0);

            //Console.WriteLine(k4.MarkaGet());
            //Console.WriteLine(k4.ModelGet());
            //Console.WriteLine(k4.PilAdediGet());

            Kumanda k5 = new Kumanda();
            k5.Marka = "Vestel";
            k5.PilAdedi = -3;

            Console.WriteLine(k5.Marka);
            Console.WriteLine(k5.PilAdedi);
        }
    }
}
