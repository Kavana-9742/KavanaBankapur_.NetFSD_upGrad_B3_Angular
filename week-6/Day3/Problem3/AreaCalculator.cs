using System;
using System.Collections.Generic;
using System.Text;

namespace LSP_Example
{
    internal class AreaCalculator
    {
        public void PrintArea(Shape shape)
        {
            Console.WriteLine("Area: " + shape.CalculateArea());
        }
    }
}
