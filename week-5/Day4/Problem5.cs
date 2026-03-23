using System;
using System.IO;

namespace DriveMonitor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                DriveInfo[] drives = DriveInfo.GetDrives();

                Console.WriteLine("Drive Information:\n");

                foreach (DriveInfo drive in drives)
                {
                    if (drive.IsReady)
                    {
                        Console.WriteLine("Drive Name      : " + drive.Name);
                        Console.WriteLine("Drive Type      : " + drive.DriveType);
                        Console.WriteLine("Total Size (GB) : " + (drive.TotalSize / (1024 * 1024 * 1024)));
                        Console.WriteLine("Free Space (GB) : " + (drive.AvailableFreeSpace / (1024 * 1024 * 1024)));

                        double freePercent = (double)drive.AvailableFreeSpace / drive.TotalSize * 100;

                        Console.WriteLine("Free Space %    : " + freePercent.ToString("F2") + "%");

                        if (freePercent < 15)
                        {
                            Console.WriteLine("WARNING: Low Disk Space!");
                        }

                        Console.WriteLine("-----------------------------------");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
