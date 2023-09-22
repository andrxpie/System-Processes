using System.Drawing;

namespace Unsafe_code
{
    internal class Program
    {
        static void Main(string[] args)
        {
            unsafe
            {
                int n, m;
                Console.Write("n: "); n = Convert.ToInt32(Console.ReadLine());
                Console.Write("m: "); m = Convert.ToInt32(Console.ReadLine());

                Random rnd = new();

                int* arrA = stackalloc int[n];
                for (int i = 0; i < n; i++)
                    arrA[i] = rnd.Next(0, 100);

                int* arrB = stackalloc int[m];
                for (int i = 0; i < m; i++)
                    arrB[i] = rnd.Next(0, 100);

                int* arrAB = stackalloc int[n + m];

                int k = 0;
                for (int i = 0; i < n; i++, k++)
                    arrAB[k] = arrA[i];
                for (int i = 0; i < m; i++, k++)
                    arrAB[k] = arrB[i];

                Console.Write("A ");
                ShowArr(arrA, n);

                Console.Write("B ");
                ShowArr(arrB, m);

                Console.Write("AB ");
                ShowArr(arrAB, n + m);
            }
        }

        static unsafe void ShowArr(int* arr, int size)
        {
            Console.Write("arr: {");
            for (int i = 0; i < size; i++)
            {
                if(i < size - 1)
                    Console.Write(" " + arr[i] + ",");
                else
                    Console.WriteLine(" " + arr[i] + " }");
            }
        }
    }
}