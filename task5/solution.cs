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
            System.Console.WriteLine("1. Get the first Electronics product");
            var query1 = products.First();
            System.Console.WriteLine(query1);
            // 2
            System.Console.WriteLine("2. Get the last product with Price > 1000 (use OrDefault — handle null)");
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
            System.Console.WriteLine("3. Get the single Furniture item with Price > 300 (what if >1 match?)");
            try
            {
                var query3 = products.Single(p => p.Price > 300);
                System.Console.WriteLine(query3);
                // System.InvalidOperationException is thrown when > 1 found
            }
            catch (Exception e)
            {
                System.Console.WriteLine($"Element found multiple times! {e.Message}");
            }
            // 4
            System.Console.WriteLine("4. Get the element at index 3");
            var query4 = products.ElementAt(3);
            System.Console.WriteLine(query4);
        }
        public static void Question3()
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
            System.Console.WriteLine("1. Are ALL products priced above 100? → bool");
            bool allAbove100 = products.All(p => p.Price > 100);
            System.Console.WriteLine(allAbove100);
            // 2
            System.Console.WriteLine("2. Is THERE ANY product in the \"Gaming\" category? → bool");
            bool gamingCategoryFound = products.Any(p => p.Category == "Gaming");
            System.Console.WriteLine(gamingCategoryFound);
            // 3
            System.Console.WriteLine("3. Does the collection CONTAIN a product named \"Chair\"? (use the default comparer on the record)");
            bool containChair = products.Any(p => p.Name == "Chair"); // couldn't make using Contains() , I should fill the rest of required fields
            System.Console.WriteLine(containChair);
            // 4
            System.Console.WriteLine("4. Are ALL Electronics products priced above 500? → bool");
            bool allElectronicsAbove500 = products.Where(p => p.Category == "Electronic").All(p => p.Price > 500);
            System.Console.WriteLine(allElectronicsAbove500);
            // 5
            System.Console.WriteLine("5. Is there ANY product cheaper than 200? → bool");
            bool anyCheaperThan200 = products.Any(p => p.Price < 200);
            System.Console.WriteLine(anyCheaperThan200);
        }
        public static void Question4()
        {
            List<Product> products =
            [
            new(1, "Laptop", 1200m, "Electronics"),
            // new(1, "Laptop", 1200m, "Electronics"),
            new(2, "Phone", 800m, "Electronics"),
            new(3, "Desk", 350m, "Furniture"),
            new(4, "Chair", 150m, "Furniture"),
            new(5, "Headphones", 200m, "Electronics"),
            ];

            System.Console.WriteLine("1. Convert to Array");
            Product[] arr = products.ToArray();
            PrintList(arr);
            System.Console.WriteLine("2. Convert to Dictionary keyed by Id");
            Dictionary<int,Product> dict = products.ToDictionary(p => p.Id);
            PrintList(dict);
            System.Console.WriteLine("3. Convert to HashSet of product Names");
            HashSet<Product> set = products.ToHashSet();
            PrintList(set);
            // ArgumentException when keys are duplicated
            System.Console.WriteLine("4. Convert to Lookup keyed by Category");
            ILookup<string,Product> lookup = products.ToLookup(p => p.Category);
            foreach(var group in lookup)
            {
                System.Console.WriteLine($"Category: {group.Key}");
                PrintList(group);
            }
            // ToLookup groups all objects with the same key
        }
        public static void Question5()
        {
            List<string> orders = ["ORD-001", "ORD-002", "ORD-003","ORD-004", "ORD-005", "ORD-006", "ORD-007"];
            System.Console.WriteLine("1. Get Page 1 (items 1–3)");
            PrintList(orders.Take(3));
            System.Console.WriteLine("2. Get Page 2 (items 4–6) ← use Skip + Take");
            PrintList(orders.Skip(3).Take(3));
            System.Console.WriteLine("3. Get the last 2 orders using TakeLast");
            PrintList(orders.TakeLast(2));
            System.Console.WriteLine("4. Drop the first and last order using Skip + SkipLast");
            PrintList(orders.Skip(1).SkipLast(1));
            System.Console.WriteLine("5. BONUS: Write a generic Paginate(source, pageNumber, pageSize) method");
            Pagination(orders, 3);
        }
        public static void Pagination<T>(IEnumerable<T> items, int chunk)
        {
            IEnumerable<T[]> pages = items.Chunk(chunk);
            for( int i = 0 ; i < pages.Count() ; i++ )
            {
                System.Console.WriteLine($"========= page number {i + 1} =========");
                PrintList(pages.ElementAt(i));
            }
        }
        record Employee(string Name, string Department, decimal Salary);
        public static void Question6()
        {
            List<Employee> employees =
            [
            new("Ali", "Engineering", 9000m),
            new("Sara", "Engineering", 8500m),
            new("Omar", "HR", 6000m),
            new("Mona", "HR", 6200m),
            new("Yara", "Marketing", 7000m),
            new("Karim", "Marketing", 7500m),
            new("Nada", "Engineering", 9500m),
            ];
            System.Console.WriteLine("1. Project to anonymous type: { FullName = Name.ToUpper(), Salary }");
            PrintList(employees.Select(e => new { FullName = e.Name.ToUpper() , e.Salary } ));
            System.Console.WriteLine("2. Project to a formatted string: \"Ali works in Engineering — EGP 9,000\"");
            PrintList(employees.Select(e => $"{e.Name} works in {e.Department} — EGP {e.Salary:N0}"));
            System.Console.WriteLine("3. Sort by Salary descending, then use indexed Select to add Rank");
            PrintList(employees.OrderByDescending(e => e.Salary).ToList().Select((e , index)=> new { Rand = index + 1 , e.Name , e.Salary }));
            System.Console.WriteLine("BONUS: Project each employee to include a \"SeniorityLevel\" property");
            PrintList(employees.Select(e => new { e.Name , e.Department , e.Salary , Seniority = e.Salary >= 9000 ? "Senior" : e.Salary >= 7000 ? "Mid" : "Junior"}));
        }
        public static void Main()
        {
            
        }
    }
}
