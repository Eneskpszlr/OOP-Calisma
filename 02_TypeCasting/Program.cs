namespace _02_TypeCasting
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region ExplicitAndImplictCasting
            //Kapalı-Bilinçsiz Dönüşüm, Implicit

            byte data1 = 100;
            int data2 = data1;

            //Açık-Bilinçli Dönüşüm, Explicit
            int data3 = 10000;
            byte data4 = (byte)data3;
            Console.WriteLine(data4);
            #endregion

            #region Convert
            string str = "123";
            int number = Convert.ToInt32(str);
            Console.WriteLine(number * 2);

            int number2 = 123;
            Byte result = Convert.ToByte(number2);

            string str1 = "A";
            char result1 = Convert.ToChar(str1);

            char chr1 = 'A';
            int result2 = Convert.ToInt32(chr1);
            Console.WriteLine(result2);

            int int1 = 75;
            char result3 = Convert.ToChar(int1);
            Console.WriteLine(result3);

            bool bool4 = true;
            int result4 = Convert.ToInt32(bool4);
            Console.WriteLine(result4);

            string char5 = "True";
            bool result5 = Convert.ToBoolean(char5);
            Console.WriteLine(result5);
            #endregion

            #region Parse
            string numberString = "123";

            int result6 = int.Parse(numberString);
            double result7 = double.Parse(numberString);

            String boolString = "True";
            bool result8 = bool.Parse(boolString);
            #endregion

            #region ToString()
            int data = 123;
            Console.WriteLine(data.ToString());
            Console.WriteLine(2.5.ToString());
            #endregion
        }
    }
}