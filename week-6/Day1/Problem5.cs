using System;
using System.Diagnostics;

namespace ConsoleApp9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TextWriterTraceListener listener =
            new TextWriterTraceListener("OrderProcessingLog.txt");

            Trace.Listeners.Add(listener);

            Trace.WriteLine("Order Processing Started");
            Trace.TraceInformation("Application started successfully");

            try
            {
                ValidateOrder();
                ProcessPayment();
                UpdateInventory();
                GenerateInvoice();

                Trace.TraceInformation("Order processed successfully");
            }
            catch (Exception ex)
            {
                Trace.WriteLine("Error occurred: " + ex.Message);
            }

            Trace.WriteLine("Order Processing Finished");

            Trace.Flush();
            Trace.Close();

            Console.WriteLine("Order processing completed. Check log file.");
            Console.ReadLine();
        }

        static void ValidateOrder()
        {
            Trace.WriteLine("Step 1: Validate Order Started");
            Console.WriteLine("Validating Order...");
            Trace.WriteLine("Step 1: Validate Order Completed");
        }

        static void ProcessPayment()
        {
            Trace.WriteLine("Step 2: Process Payment Started");
            Console.WriteLine("Processing Payment...");
            Trace.WriteLine("Step 2: Process Payment Completed");
        }

        static void UpdateInventory()
        {
            Trace.WriteLine("Step 3: Update Inventory Started");
            Console.WriteLine("Updating Inventory...");
            Trace.WriteLine("Step 3: Update Inventory Completed");
        }

        static void GenerateInvoice()
        {
            Trace.WriteLine("Step 4: Generate Invoice Started");
            Console.WriteLine("Generating Invoice...");
            Trace.WriteLine("Step 4: Generate Invoice Completed");
        }
    
    }
}
