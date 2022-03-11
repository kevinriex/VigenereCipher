using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VigenereCipher
{
    static public class Vigenere
    {
        private static char[] abc = new char[26] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' }; // Array mit dem ABC ohne Umlaute 

        /// <summary>
        /// Gibt den Index den eingegebenen Buchstaben im Aplhabet zurück.
        /// </summary>
        /// <param name="ch">Buchstabe</param>
        /// <returns>Integer Index(Buchstabe)</returns>
        private static int getCharIndex(char ch)
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
        /// <summary>
        /// Die eigentliche Viginere Verschlüsselung
        /// </summary>
        /// <param name="clear">Klartext Buchstabe</param>
        /// <param name="key">Schlüsselwort Buchstabe</param>
        /// <returns>Integer ViginereIndex(Buchstabe)</returns>
        private static int getViginereCharIndex(char clear, char key)
        {
            int index = 0;
            int clearIndex = getCharIndex(clear);
            int keyIndex = getCharIndex(key);
            index = clearIndex + keyIndex;
            if (index > 25) // Wenn die Beiden Indexe größer als das Alphabet sind fängt er wieder vorne an.
            {
                index = index - 26;
            }
            return index;
        }
        /// <summary>
        /// Startet die Viginere Verschlüsselung
        /// </summary>
        /// <param name="sentence">Klartext Satz</param>
        /// <param name="key">Schüssel</param>
        /// <returns>Verschlüsselten Satz</returns>
        public static string start(string sentence, string key)
        {
            string aws = "";
            List<char> awsL = new List<char>();
            List<char> sentenceL = sentence.ToList(); // Macht aus einem String einen Array
            List<char> keyL = key.ToList();
            keylen(sentenceL, keyL);
            //printLists(sentenceL, keyL);

            List<int> awsLint = new List<int>(); // Liste der Indexe
            List<Array> mixed = new List<Array>(); // Liste aus Arrays [Sentence Index, Key index]
            for (int i = 0; i < sentenceL.Count; i++)
            {
                mixed.Add(new char[2] { sentenceL[i], keyL[i] });
            }
            foreach (Array item in mixed)
            {
                awsLint.Add(getViginereCharIndex(Convert.ToChar(item.GetValue(0)), Convert.ToChar(item.GetValue(1)))); // Startet die Viginere Verschlüsselung
            }
            foreach (var item in awsLint)
            {
                awsL.Add(abc[item]); // Macht aus Index wieder einen Buchstaben
            }

            foreach (var a in awsL)
            {
                aws = aws + a; // Macht aus der Char Liste einen String
            }
            aws = aws.ToLower();
            Console.WriteLine("\nThe Encoded Message is:");
            Console.WriteLine(aws);
            return aws;
        }
        /// <summary>
        /// Gibt die Listen in der Console aus (DEBUG)
        /// </summary>
        /// <param name="sentenceL">Liste der Klartext Buchstaben</param>
        /// <param name="keyL">Liste der Schlüssel Buchstaben</param>
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
        /// <summary>
        /// Erweitert den Key auf die geforderte Länge
        /// </summary>
        /// <param name="sentenceL">Liste der Klartext Buchstaben</param>
        /// <param name="keyL">Liste der Schlüssel Buchstaben</param>
        private static void keylen(List<char> sentenceL, List<char> keyL)
        {
            int max = keyL.Count;
            if (sentenceL.Count > keyL.Count) // Wenn Satz länger als Key
            {
                while (sentenceL.Count != keyL.Count) // Wenn Satz nicht gleich lang wie Key
                {
                    if (sentenceL.Count - keyL.Count < max) // Wenn Satzlänge - Keylänge kleiner als Orginal Key
                    {
                        max = sentenceL.Count - keyL.Count; // Setzt den Max Wert auf die verbleibende Anzahl an Chars
                    }
                    for (int i = 0; i < max; i++)
                    {
                        keyL.Add(keyL[i]); // Fügt die Buchstaben des Orginal Keys hinten an.
                    }
                }
            }
            else
            {
                keyL.RemoveRange(sentenceL.Count, keyL.Count - sentenceL.Count); // Kürzt den Key auf die Satzlänge
            }
        }
    }
}