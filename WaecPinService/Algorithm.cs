namespace WaecPinService
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            int[] numbers = { 1, 2, 3, 6 };
            bool result = CanSumToLargest(numbers);
            Console.WriteLine(result ? "Yes" : "No");
        }

        static bool CanSumToLargest(int[] numbers)
        {
            if (numbers.Length < 2)
                return false;
            int maxNumber = numbers.Max();
            int sumOfOthers = numbers.Where(num => num != maxNumber).Sum();
            return IsSubsetSum(numbers, numbers.Length, sumOfOthers);
        }

        static bool IsSubsetSum(int[] numbers, int n, int sum)
        {
            if (sum == 0)
                return true;
            if (n == 0 && sum != 0)
                return false;
            if (numbers[n - 1] > sum)
                return IsSubsetSum(numbers, n - 1, sum);

            return IsSubsetSum(numbers, n - 1, sum)
                   || IsSubsetSum(numbers, n - 1, sum - numbers[n - 1]);
        }
    }

}
