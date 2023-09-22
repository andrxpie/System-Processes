using System.Security.Cryptography;

namespace Threads_Intro
{
    public class Pair
    {
        public int a { get; set; }
        public int b { get; set; }
    }

    internal class Program
    {
        static void task1()
        {
            for (int i = 1 ; i < 51; i++)
            {
                Console.WriteLine(i);
                Thread.Sleep(50);
            }
        }

        static void task2(object obj)
        {
            for (int i = ((Pair)obj).a ; i <= ((Pair)obj).b; i++)
            {
                Console.WriteLine(i);
                Thread.Sleep(50);
            }
        }

        static void Main(string[] args)
        {
            //Thread thread1 = new Thread(task1);
            //thread1.Start();

            //Console.WriteLine("\n >>> ");

            //int p1, p2;
            //Console.Write("p1: "); p1 = Convert.ToInt32(Console.ReadLine());
            //Console.Write("p2: "); p2 = Convert.ToInt32(Console.ReadLine());

            //Thread thread2 = new Thread(task2);
            //thread2.Start(new Pair{ a = p1, b = p2 });

            //Console.WriteLine("\n >>> ");

            int p1, p2, p3;
            Console.Write("p1: "); p1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("p2: "); p2 = Convert.ToInt32(Console.ReadLine());
            Console.Write("p3: "); p3 = Convert.ToInt32(Console.ReadLine());

            Thread thread3 = new Thread(task2);
            thread3.Start(new Pair{ a = p1, b = p2 });
            for (int i = 0; i < p3; i++)
            {
                thread3.Join();
            }
        }
    }
}