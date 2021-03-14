using System;
using System.IO;
using System.Text;

namespace XOR_Sifrovani
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Valid file names ... .txt, .cry . | e. g. test.cry");
            while (true)
            {
                Console.Write("Enter file name: ");
                try
                {
                    Crypto("PRAVDA", Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine("-Error: " + e.Message);
                }
            }
        }
        static void Crypto(string key, string fileName)
        {
            string oldFile = File.ReadAllText(fileName);

            StringBuilder newFileContents = new StringBuilder();
            for (int i = 0; i < oldFile.Length; i++)
            {
                newFileContents.Append((char)(key[i % 5] ^ oldFile[i]));
            }
            
            string newFileName = fileName.Substring(0,fileName.IndexOf('.'));

            string ext = fileName.Substring(fileName.IndexOf('.'));
            if (ext == ".txt")
                newFileName += ".cry";
            else if (ext == ".cry")
                newFileName += ".txt";
            else
                throw new Exception("Unsupported file extension");

            File.Create(newFileName).Dispose();
            File.AppendAllText(newFileName, newFileContents.ToString());
            Console.WriteLine($"Result: \"{newFileContents}\"");
            Console.WriteLine($"- Text was saved in the file '{newFileName}'");
        }
    }
}
