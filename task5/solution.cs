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
        public static void Main()
        {
            // Question 1
            List<int> numbers = [3, 18, 7, 42, 10, 5, 29, 14, 6, 100];
            var query = numbers.Where(n => n % 2 == 0 && n > 10).OrderByDescending(n => n);
            query = from number in numbers
                        where number % 2 == 0 && number > 10
                        orderby number descending
                        select number;
            PrintList(query);
            
        }
    }
}
