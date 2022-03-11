namespace VigenereCipher
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("#################################");
            Console.WriteLine("-------- Vigenère Cipher --------");
            Console.WriteLine("#################################");
            Console.WriteLine("\n\n");

            Vigenere.start("herrjordanistnett", "zwerg");
        }
    }
}