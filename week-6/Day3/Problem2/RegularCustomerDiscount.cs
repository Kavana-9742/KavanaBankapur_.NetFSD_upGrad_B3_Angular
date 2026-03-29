using System;
using System.Collections.Generic;
using System.Text;

namespace OCP_Example
{
    internal class RegularCustomerDiscount : IDiscountStrategy
    {
        public double CalculateDiscount(double amount)
        {
            return amount * 0.05;
        }
    }
    
}
