using System;
using System.Collections.Generic;
using System.Text;

namespace OCP_Example
{
    internal class VipCustomerDiscount : IDiscountStrategy
    {
        public double CalculateDiscount(double amount)
        {
            return amount * 0.20; // 20% discount
        }
    }
   
}
