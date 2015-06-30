using System;
using System.Security.Cryptography;
using System.IO;

namespace SignatureGenerator
{
    class Program
    {
        static byte[] ReadExactly(FileStream s, int n)
        {
            byte[] buf = new byte[n];
            int remaining = n;
            int pos = 0;
            while (remaining > 0)
            {
                int nread = s.Read(buf, pos, remaining);
                if (nread == 0) // end of file
                {
                    throw new FileFormatException("EOF encountered");
                }
                remaining -= nread;
                pos += nread;
            }
            return buf;
        }

        static void Main(string[] args)
        {

            //Убрать  Windows.Base

            string path;
            int blockSize;

            Console.Write("Full path to file: ");
            path = Console.ReadLine();
            Console.Write("Size of block (Kb): ");
            if (!Int32.TryParse(Console.ReadLine(), out blockSize))
            {
                Console.WriteLine("Set default value (1Mb). Please, press 'Enter' to continue.");
                Console.ReadLine();
                blockSize = 1024;
            }
            

            DateTime start_time = DateTime.Now;
            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                MD5 myHash = new MD5CryptoServiceProvider();

                long remainingBytes = fs.Length;
                int bufSize = blockSize * 1024;
                int numOfBlock = 1;
                while (remainingBytes > 0)
                {
                    byte[] buf = ReadExactly(fs, (int)Math.Min(remainingBytes, bufSize));
                    remainingBytes -= buf.Length;

                    myHash.ComputeHash(buf);
                    Console.WriteLine(numOfBlock + " block:  " + BitConverter.ToString(myHash.Hash).Replace("-", String.Empty));

                    numOfBlock++;
                }
            }
            Console.WriteLine();
            Console.WriteLine(DateTime.Now - start_time);

            Console.ReadLine();
        }
    }
}
