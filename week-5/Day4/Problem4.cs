using System;
using System.IO;

namespace DirectoryAnalysis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Enter Root Directory Path: ");
                string rootPath = Console.ReadLine();

                if (!Directory.Exists(rootPath))
                {
                    Console.WriteLine("Invalid directory path.");
                    return;
                }

                DirectoryInfo rootDir = new DirectoryInfo(rootPath);
                DirectoryInfo[] subDirs = rootDir.GetDirectories();

                if (subDirs.Length == 0)
                {
                    Console.WriteLine("No subdirectories found.");
                    return;
                }

                Console.WriteLine("\nDirectory Details:\n");

                foreach (DirectoryInfo dir in subDirs)
                {
                    FileInfo[] files = dir.GetFiles();
                    int fileCount = files.Length;

                    Console.WriteLine("Folder Name : " + dir.Name);
                    Console.WriteLine("File Count  : " + fileCount);
                    Console.WriteLine("----------------------------------");
                }
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("Access denied to the directory.");
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("Directory not found.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
