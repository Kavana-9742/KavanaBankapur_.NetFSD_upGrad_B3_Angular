using System;
using System.IO;
using System.Linq.Expressions;
using System.Text;

namespace Store
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = "log.txt";

            try
            {
                while (true)
                {
                    Console.Write("Enter a log message (or type 'exit' to stop): ");
                    String message = Console.ReadLine();

                    if (message.ToLower() == "exit")
                    {
                        break;
                    }
                    byte[] data = Encoding.UTF8.GetBytes(message + Environment.NewLine);

                    using (FileStream fs = new FileStream(filePath, FileMode.Append, FileAccess.Write))
                    {
                        fs.Write(data, 0, data.Length);
                    }
                    Console.WriteLine("Message successfully written in file. \n");
                }
                Console.WriteLine("Program ended. Check log.txt for stored messages.");
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("Error: You do not have permission to access the file.");
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("Error: The specified path is invalid.");
            }
            catch (IOException ex)
            {
                Console.WriteLine("File error: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unexpected error: " + ex.Message);
            }
        }
    }
}
