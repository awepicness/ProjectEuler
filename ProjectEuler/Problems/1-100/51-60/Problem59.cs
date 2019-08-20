using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ProjectEuler.Problems
{
    class Problem59
    {
        public void Method()
        {
            Console.WriteLine("decrypt the given file and find the sum of the ascii values in the original text");

            // answer from mathblog.dk, i know nothing about encryption

            string filename = "59cipher.txt";
            const int keyLength = 3;

            int[] message = File.ReadAllText(filename).Split(',').Select(int.Parse).ToArray();
            int[] key = Analysis(message, keyLength);
            int[] decryptedMessage = EncryptLinq(message, key);
            int result = decryptedMessage.Sum();


            Console.WriteLine($"The sum of the decrypted message is {result}");
            Console.WriteLine("This is the message:");
            Console.WriteLine();
            foreach (var character in decryptedMessage)
                Console.Write(Convert.ToChar(character));
            
            Console.WriteLine();
        }

        private int[] Encrypt(int[] message, int[] key)
        {
            int[] encryptedMessage = new int[message.Length];

            for (int i = 0; i < message.Length; i++)
                encryptedMessage[i] = message[i] ^ key[i % key.Length];
            
            return encryptedMessage;
        }

        private int[] EncryptLinq(int[] message, int[] key)
        {
            IEnumerable<int> repeatedKey = Enumerable.Range(0, message.Length).Select(x => key[x % key.Length]);
            return message.Zip(repeatedKey, (x, y) => (x ^ y)).ToArray();
        }

        private int[] Analysis(int[] message, int keyLength)
        {
            int maxsize = 0;
            for (int i = 0; i < message.Length; i++)
                if (message[i] > maxsize) maxsize = message[i];
            
            int[,] aMessage = new int[keyLength, maxsize + 1];
            int[] key = new int[keyLength];

            for (int i = 0; i < message.Length; i++)
            {
                int j = i % keyLength;
                aMessage[j, message[i]]++;
                if (aMessage[j, message[i]] > aMessage[j, key[j]]) key[j] = message[i];
            }

            int spaceAscii = 32;
            for (int i = 0; i < keyLength; i++)
                key[i] = key[i] ^ spaceAscii;
            
            return key;
        }
    }
}
