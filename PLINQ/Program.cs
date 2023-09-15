using System.Security.Cryptography.X509Certificates;

namespace PLINQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Task 1

            //Parallel.Invoke(() => Factorial(3));
            //Console.ReadLine();


            // Task 2

            //Console.Write("y: "); int y = Convert.ToInt32(Console.ReadLine());
            //Parallel.Invoke(() => Factorial(y), () => DigitsCount(y), () => DigitsSum(y));

            //Console.ReadLine();


            // Task 3

            //Console.Write("x: "); int x = Convert.ToInt32(Console.ReadLine());
            //Console.Write("y: "); int y = Convert.ToInt32(Console.ReadLine());

            //Parallel.For(x, y, WriteMultiplyTableInFile);

            //Console.ReadLine();


            // Task 4

            //List<int> nums = new List<int>();
            //string[] numsStr = File.ReadAllLines("nums.txt");

            //foreach (var i in numsStr)
            //    nums.Add(Convert.ToInt32(i));

            //Parallel.ForEach(nums, Factorial);

            //Console.ReadLine();


            // Task 5

            List<int> nums = new List<int>();
            string[] numsStr = File.ReadAllLines("nums.txt");

            foreach (var i in numsStr)
                nums.Add(Convert.ToInt32(i));

            var res = nums.AsParallel().Sum();
            Console.WriteLine("sum: " + res);

            res = nums.Max();
            Console.WriteLine("max: " + res);

            res = nums.Min();
            Console.WriteLine("min: " + res);
        }

        static void Factorial(int x)
        {
            int result = 1;

            for (int i = 1; i <= x; i++)
            {
                result *= i;
            }
            Console.WriteLine($"C://x (factorial): {result}");
        }

        static void DigitsCount(int y)
        {
            double result = Math.Floor(Math.Log10(y) + 1);

            Console.WriteLine($"C://x (count): {result}");
        }

        static void DigitsSum(int x)
        {
            int result = 0;
            while (x != 0) {
                result += x % 10;
                x /= 10;
            }

            Console.WriteLine($"C://x (sum): {result}");
        }

        static void WriteMultiplyTableInFile(int x)
        {
            string mt = "";

            for (int i = 1; i <= 10; i++)
                mt += $"{x} * {i} = {x * i}\n";

            File.WriteAllText($"mt for {x}.txt", mt);
        }
    }
}