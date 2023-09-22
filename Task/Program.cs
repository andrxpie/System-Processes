using System;

namespace Task_Class
{
    internal class Program
    {
        public static int[] arr = { 123, 2, 321, 2, 55 };
        static void Main(string[] args)
        {
            // Task 1

            //Task task = new Task(NowTime);
            //task.Start();

            //Task.Factory.StartNew(NowTime);

            //Task.Run(NowTime);

            //Console.ReadKey();


            // Task 2

            //Task.Run(ShowAllSimpleNumsTo1000);
            //Task.WaitAll();

            //Console.ReadKey();


            // Task 3

            //Task task = new Task(GetDiapazone);
            //task.Start();
            //task.Wait();            


            // Task 4

            //Task[] taskArr = { new Task(FindMin), new Task(FindMax), new Task(FindAvg), new Task(FindSum) };

            //for (int i = 0; i < taskArr.Length; i++)
            //{
            //    taskArr[i].Start();
          
            //}

            //Console.ReadKey();


            // Task 5

            Console.Write("default: { ");
            for (int i = 0; i < arr.Length; i++)
            {
                if (i < arr.Length - 1) Console.Write(arr[i] + ", ");
                else Console.WriteLine(arr[i] + " }");
            }

            Task task = Task.Run(ClearArrDoubles).ContinueWith(SortArr).ContinueWith(SelectValue);
            task.Wait();
           

            Console.ReadKey();
        }

        static void NowTime()
        {
            while (true)
            {
                Console.WriteLine(DateTime.Now + "\n");
                Thread.Sleep(1000);
            }
        }

        static void ShowAllSimpleNumsTo1000()
        {
            for (int i = 2; i <= 1000; i++)
            {
                for (int j = 2; j <= 1000; j++)
                {
                    if (i % j == 0) break;
                    else
                    {
                        Console.WriteLine(i);
                        Thread.Sleep(20);
                    }
                }
            }
        }

        static void GetDiapazone()
        {
            Console.Write("from (min 2): "); int from = Convert.ToInt32(Console.ReadLine());
            Console.Write("to: "); int to = Convert.ToInt32(Console.ReadLine());

            ShowAllSimpleNumsTo1000Mod(from, to);
        }

        static void ShowAllSimpleNumsTo1000Mod(int from, int to)
        {
            for (int i = from; i <= to; i++)
            {
                for (int j = 2; j <= 1000; j++)
                {
                    if (i % j == 0) break;
                    else
                    {
                        Console.WriteLine(i);
                        Thread.Sleep(20);
                    }
                }
            }

            Console.ReadKey();
        }

        static void FindMin()
        {
            Console.WriteLine($"Min: {arr.Min()}");
        }

        static void FindMax()
        {
            Console.WriteLine($"Max: {arr.Max()}");
        }

        static void FindAvg()
        {
            Console.WriteLine($"Avg: {arr.Average()}");
        }

        static void FindSum()
        {
            Console.WriteLine($"Sum: {arr.Sum()}");
        }

        static void ClearArrDoubles()
        {
            arr = arr.Distinct().ToArray();

            Console.Write("doubles cleared: { ");
            for (int i = 0; i < arr.Length; i++)
            {
                if (i < arr.Length - 1) Console.Write(arr[i] + ", ");
                else Console.WriteLine(arr[i] + " }");
            }
        }

        static void SortArr(Task task)
        {
            arr = arr.Order().ToArray();

            Console.Write("sorted: { ");
            for (int i = 0; i < arr.Length; i++)
            {
                if (i < arr.Length - 1) Console.Write(arr[i] + ", ");
                else Console.WriteLine(arr[i] + " }");
            }
        }

        static void SelectValue(Task task)
        {
            Console.Write("x: "); int x = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("ans: " + BinarySearch(x));
        }

        static bool BinarySearch(int x)
        {
            return arr.Contains(x);
        }
    }
}