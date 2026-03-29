using System;
using System.Collections.Generic;
using System.Text;

namespace OCP_Example
{
    internal class PriceCalculator
    {
        private IDiscountStrategy _discountStrategy;

        public PriceCalculator(IDiscountStrategy discountStrategy)
        {
            _discountStrategy = discountStrategy;
        }

        public void CalculateFinalPrice(double amount)
        {
            double discount = _discountStrategy.CalculateDiscount(amount);
            double finalPrice = amount - discount;

            Console.WriteLine("Original Amount : " + amount);
            Console.WriteLine("Discount        : " + discount);
            Console.WriteLine("Final Price     : " + finalPrice);
        }
    }
}
