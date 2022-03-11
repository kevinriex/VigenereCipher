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

            Console.WriteLine("Please enter a Sentence (without Spaces):");
            string ein = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Plase enter a Keyword");
            string key = Convert.ToString(Console.ReadLine());


            // Vigenere.start("herrjordanistnett", "zwerg");
            Vigenere.start(ein, key);
        }
    }
}