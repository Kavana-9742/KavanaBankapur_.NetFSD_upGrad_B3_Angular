using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace ISP_Example
{
    internal class AdvancedPrinter : IPrinter, IScanner, IFax
    {
        public void Print()
        {
            Console.WriteLine("Advanced Printer: Printing document...");
        }

        public void Scan()
        {
            Console.WriteLine("Advanced Printer: Scanning document...");
        }

        public void Fax()
        {
            Console.WriteLine("Advanced Printer: Sending fax...");
        }
    }
    
}
