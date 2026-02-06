using System;

namespace Question3 {
    internal class Program {
        static bool isPrime(int num) {
            for (int i = 2 ; i * i <= num ; i++ ) {
                if(num % i == 0){
                    return false;
                }
            }
            return true;
        }
        static List<List<int>> EvensOddsPrimes(List<int> nums) {
            List<List<int>> ans = new List<List<int>> {
                new List<int> {} ,
                new List<int> {} ,
                new List<int> {}
            };
            for(int i = 0 ; i < nums.Count ; i++) {
                // even or odd
                if(nums[i] % 2 == 0){
                    ans[0].Add(nums[i]);
                } else {
                    ans[1].Add(nums[i]);
                }

                if(isPrime(nums[i])){
                    ans[2].Add(nums[i]);
                }
            }
            return ans;
        }
        static void PrintList(List<int> nums){
            System.Console.Write("{ " +nums[0]);
            for(int i = 1 ; i < nums.Count ; i++) {
                System.Console.Write(" , " + nums[i]);
            }
            System.Console.WriteLine(" }");
        }
        static void Main() {
            List<int> numbers = new List<int> { 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            List<List<int>> answer = EvensOddsPrimes(numbers);

            System.Console.Write("Even Numbers: ");
            PrintList(answer[0]);

            System.Console.Write("Odd Numbers: ");
            PrintList(answer[1]);

            System.Console.Write("Prime Numbers: ");
            PrintList(answer[2]);
        }
    }
}