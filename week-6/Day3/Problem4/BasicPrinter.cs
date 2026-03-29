using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace ISP_Example
{
    internal class BasicPrinter : IPrinter
    {
        public void Print()
        {
            Console.WriteLine("Basic Printer: Printing document...");
        }
    }
    
}
