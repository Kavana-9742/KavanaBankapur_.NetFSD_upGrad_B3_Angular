using System;
using System.IO;

namespace FileInfoExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Enter folder path: ");
                string folderPath = Console.ReadLine();

                if (!Directory.Exists(folderPath))
                {
                    Console.WriteLine("Invalid directory path.");
                    return;
                }

                string[] files = Directory.GetFiles(folderPath);

                if (files.Length == 0)
                {
                    Console.WriteLine("No files found in the directory.");
                    return;
                }

                Console.WriteLine("\nFile Details:\n");

                int count = 0;

                foreach (string file in files)
                {
                    FileInfo fileInfo = new FileInfo(file);

                    Console.WriteLine("File Name     : " + fileInfo.Name);
                    Console.WriteLine("File Size     : " + fileInfo.Length + " bytes");
                    Console.WriteLine("Created Date  : " + fileInfo.CreationTime);
                    Console.WriteLine("-----------------------------------");

                    count++;
                }

                Console.WriteLine($"\nTotal Files: {count}");
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("Access denied to the folder.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
