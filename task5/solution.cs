using System;
using System.Linq;

namespace LinqTask
{
    internal class Program
    {
        public static void PrintList<T>(IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                System.Console.WriteLine(item);
            }
        }
        public static void Question1 ()
        {
            List<int> numbers = [3, 18, 7, 42, 10, 5, 29, 14, 6, 100];
            var query = numbers.Where(n => n % 2 == 0 && n > 10).OrderByDescending(n => n);
            query = from number in numbers
                        where number % 2 == 0 && number > 10
                        orderby number descending
                        select number;
            PrintList(query);
        }
        record Product(int Id, string Name, decimal Price, string Category);
        public static void Question2 ()
        {
            List<Product> products =
            [
            new(1, "Laptop", 1200m, "Electronics"),
            new(2, "Phone", 800m, "Electronics"),
            new(3, "Desk", 350m, "Furniture"),
            new(4, "Chair", 150m, "Furniture"),
            new(5, "Headphones", 200m, "Electronics"),
            ];
            
            // 1
            System.Console.WriteLine("==================== point 1 ====================");
            var query1 = products.First();
            System.Console.WriteLine(query1);
            // 2
            System.Console.WriteLine("==================== point 2 ====================");
            var query2 = products.LastOrDefault(p => p.Price > 1000);
            System.Console.WriteLine(query2);
            try
            {
                query2 = products.Last(p => p.Price > 1000);
                System.Console.WriteLine(query2);
            }
            catch (Exception e)
            {
                System.Console.WriteLine($"Element not found! {e.Message}");
            }
            // 3
            System.Console.WriteLine("==================== point 3 ====================");
            try
            {
                var query3 = products.Single(p => p.Price > 300);
                System.Console.WriteLine(query3);
            }
            catch (Exception e)
            {
                System.Console.WriteLine($"Element found multiple times! {e.Message}");
            }
            // 4
            System.Console.WriteLine("==================== point 4 ====================");
            var query4 = products.ElementAt(3);
            System.Console.WriteLine(query4);
        }
        public static void Main()
        {

        }
    }
}
