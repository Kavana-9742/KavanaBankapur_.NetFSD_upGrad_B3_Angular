using System;
using System.Collections.Generic;
using System.Text;

namespace OCP_Example
{
    internal interface IDiscountStrategy
    {
        double CalculateDiscount(double amount);
    }
}
