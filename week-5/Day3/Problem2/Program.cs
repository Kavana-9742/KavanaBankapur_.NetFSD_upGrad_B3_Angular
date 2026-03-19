using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqCodeTemplate
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Product product = new Product();
            var products = product.GetProducts();

            //1.Write a LINQ query to search and display all products with category “FMCG”.
            Console.WriteLine("\n1. FMCG Products:");
            var q1 = from p in products
                     where p.ProCategory == "FMCG"
                     select p;
            foreach (var item in q1)
            {
                Console.WriteLine($"{item.ProCode}\t{item.ProName}\t{item.ProMrp}");
            }

            //2. Write a LINQ query to search and display all products with category “Grain”.
            Console.WriteLine("\n2. Grain Products:");
            var q2 = from p in products
                     where p.ProCategory == "Grain"
                     select p;
            foreach (var item in q2)
            {
                Console.WriteLine($"{item.ProCode}\t{item.ProName}\t{item.ProMrp}");
            }

            //3. Write a LINQ query to sort products in ascending order by product code.
            Console.WriteLine("\n3. Sorted by Product Code:");
            var q3 = from p in products
                     orderby p.ProCode
                     select p;
            foreach (var item in q3)
            {
                Console.WriteLine($"{item.ProCode}\t{item.ProName}");
            }

            //4. Write a LINQ query to sort products in ascending order by product Category.
            Console.WriteLine("\n4. Sorted by Category:");
            var q4 = from p in products
                     orderby p.ProCategory
                     select p;
            foreach (var item in q4)
            {
                Console.WriteLine($"{item.ProCategory}\t{item.ProName}");
            }

            //5. Write a LINQ query to sort products in ascending order by product Mrp.
            Console.WriteLine("\n5. Sorted by MRP(Asc):");
            var q5 = from p in products
                     orderby p.ProMrp
                     select p;
            foreach (var item in q5)
            {
                Console.WriteLine($"{item.ProName}\t{item.ProMrp}");
            }

            //6. Write a LINQ query to sort products in descending order by product Mrp.
            Console.WriteLine("\n6. Sorted by MRP(Desc):");
            var q6 = from p in products
                     orderby p.ProMrp descending
                     select p;
            foreach (var item in q6)
            {
                Console.WriteLine($"{item.ProName}\t{item.ProMrp}");
            }

            //7. Write a LINQ query to display products group by product Category.
            Console.WriteLine("\n7. Group by Category:");
            var q7 = from p in products
                     group p by p.ProCategory;
            foreach (var group in q7)
            {
                Console.WriteLine($"\nCategory: {group.Key}");
                foreach(var item in group)
                {
                    Console.WriteLine($"{item.ProName}\t{item.ProMrp}");
                }
            }

            //8.Write a LINQ query to display products group by product Mrp.
            Console.WriteLine("\n8. Group by MRP:");
            var q8 = from p in products
                     group p by p.ProMrp;
            foreach (var group in q8)
            {
                Console.WriteLine($"\nMRP: {group.Key}");
                foreach(var item in group)
                {
                    Console.WriteLine($"{item.ProName}");
                }
            }

            //9. Write a LINQ query to display product detail with highest price in FMCG category.
            Console.WriteLine("\n9. Highest priced FMCG product:");
            var q9 = (from p in products
                      where p.ProCategory == "FMCG"
                      orderby p.ProMrp descending
                      select p).FirstOrDefault();
            if (q9 != null)
                Console.WriteLine($"{q9.ProName}\t{q9.ProMrp}");

            //10. Write a LINQ query to display count of total products.
            Console.WriteLine("\n10. Total products:");
            var q10 = (from p in products select p).Count();
            Console.WriteLine(q10);

            //11. Write a LINQ query to display count of total products with category FMCG.
            Console.WriteLine("\n11. Total FMCG products:");
            var q11 = (from p in products
                       where p.ProCategory == "FMCG"
                       select p).Count();
            Console.WriteLine(q11);

            //12.Write a LINQ query to display Max price.
            Console.WriteLine("\n12. Max Price:");
            var q12 = (from p in products select p.ProMrp).Max();
            Console.WriteLine(q12);

            //13.Write a LINQ query to display Min price.
            Console.WriteLine("\n13. Min Price:");
            var q13 = (from p in products select p.ProMrp).Min();
            Console.WriteLine(q13);

            //14. Write a LINQ query to display whether all products are below Mrp Rs.30 or not.
            Console.WriteLine("\n14. All products below Rs.30:");
            var q14 = (from p in products select p).All(p => p.ProMrp < 30);
            Console.WriteLine(q14);

            //15. 15. Write a LINQ query to display whether any products are below Mrp Rs.30 or not.
            Console.WriteLine("\n15. Any product below Rs.30:");
            var q15 = (from p in products select p).Any(p => p.ProMrp < 30);
            Console.WriteLine(q15);

            Console.ReadLine();
        }
    }
}
