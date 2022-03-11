using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VigenereCipher
{
    static public class Vigenere
    {
        private static char[] abc = new char[26] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };


        public static int getCharIndex(char ch)
        {
            ch = char.ToUpper(ch);
            int index = 0;
            for (int i = 0; i < abc.Length; i++)
            {
                if (abc[i] == ch)
                {
                    return i;
                }
            }
            return index;
        }

        public static int getViginereCharIndex(char clear, char key)
        {
            int index = 0;
            int clearIndex = getCharIndex(clear);
            int keyIndex = getCharIndex(key);
            index = clearIndex + keyIndex;
            if (index > 25)
            {
                index = index - 26;
            }
            return index;
        }

        public static string start(string sentence, string key)
        {
            string aws = "";
            List<char> awsL = new List<char>();
            List<char> sentenceL = sentence.ToList();
            List<char> keyL = key.ToList();
            keylen(sentenceL, keyL);
            //printLists(sentenceL, keyL);

            List<int> awsLint = new List<int>();
            List<Array> mixed = new List<Array>();
            for (int i = 0; i < sentenceL.Count; i++)
            {
                mixed.Add(new char[2] { sentenceL[i], keyL[i] });
            }
            foreach (Array item in mixed)
            {
                awsLint.Add(getViginereCharIndex(Convert.ToChar(item.GetValue(0)), Convert.ToChar(item.GetValue(1))));
            }
            //foreach (char s in sentenceL)
            //{
            //    foreach (char k in keyL)
            //    {
            //        awsLint.Add(getViginereCharIndex(s, k));
            //    }

            //}
            foreach (var item in awsLint)
            {
                awsL.Add(abc[item]);
                //Console.Write(item + " ");
            }

            foreach (var a in awsL)
            {
                aws = aws + a;
            }
            aws = aws.ToLower();
            Console.WriteLine("\nThe Encoded Message is:");
            Console.WriteLine(aws);
            return aws;
        }

        private static void printLists(List<char> sentenceL, List<char> keyL)
        {
            foreach (char item in sentenceL)
            {
                Console.Write(item);
            }
            Console.WriteLine("\n");
            foreach (char item in keyL)
            {
                Console.Write(item);
            }
            Console.WriteLine("\n");
        }

        private static void keylen(List<char> sentenceL, List<char> keyL)
        {
            int max = keyL.Count;
            if (sentenceL.Count > keyL.Count)
            {
                while (sentenceL.Count != keyL.Count)
                {
                    if (sentenceL.Count - keyL.Count < max)
                    {
                        max = sentenceL.Count - keyL.Count;
                    }
                    for (int i = 0; i < max; i++)
                    {
                        keyL.Add(keyL[i]);
                    }
                }
            }
            else
            {
                keyL.RemoveRange(sentenceL.Count, keyL.Count - sentenceL.Count);
            }
        }
    }
}